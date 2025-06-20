# rl_agent.py
import socket, json, torch
import torch.nn.functional as F
from model import PolicyNetwork
from eeg_env import EEGEnv

HOST = '127.0.0.1'
PORT = 5000

env = EEGEnv()
policy = PolicyNetwork()
optimizer = torch.optim.Adam(policy.parameters(), lr=1e-3)

log_probs = []
rewards = []

def select_action(state):
    state_tensor = torch.FloatTensor(state)
    probs = policy(state_tensor)
    dist = torch.distributions.Categorical(probs)
    action = dist.sample()
    log_probs.append(dist.log_prob(action))
    return action.item()

def finish_episode():
    discounted = []
    R = 0
    for r in reversed(rewards):
        R = r + 0.99 * R
        discounted.insert(0, R)
    discounted = torch.tensor(discounted)
    discounted = (discounted - discounted.mean()) / (discounted.std() + 1e-6)

    loss = -torch.stack([lp * r for lp, r in zip(log_probs, discounted)]).sum()
    optimizer.zero_grad()
    loss.backward()
    optimizer.step()
    log_probs.clear()
    rewards.clear()

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.bind((HOST, PORT))
    s.listen()
    print(f"Listening on {HOST}:{PORT}")
    conn, addr = s.accept()
    with conn:
        print('Connected by', addr)
        buffer = ""
        while not env.is_done():
            data = conn.recv(1024)
            if not data: break
            buffer += data.decode()
            while '\n' in buffer:
                line, buffer = buffer.split('\n', 1)
                try:
                    packet = json.loads(line)
                    env.update_state(packet)
                    state = env.get_state()
                    action = select_action(state)
                    reward = env.get_reward(action)
                    rewards.append(reward)
                    print(f"State: {state}, Action: {action}, Reward: {reward}")
                except Exception as e:
                    print("Bad packet:", e)

        finish_episode()
