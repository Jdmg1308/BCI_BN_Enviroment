# eeg_env.py
import numpy as np

class EEGEnv:
    def __init__(self):
        self.state = np.zeros(5)  # alpha, beta, delta, theta, gamma
        self.timestep = 0

    def update_state(self, packet):
        self.state = np.array([
            packet["alpha"],
            packet["beta"],
            packet["delta"],
            packet["theta"],
            packet["gamma"]
        ])
        self.timestep += 1

    def get_state(self):
        return self.state

    def get_reward(self, action):
        # Example: positive reward if alpha increases after relaxing audio
        if action == 0:  # e.g., play calm audio
            return self.state[0]  # reward = alpha
        elif action == 1:  # e.g., play stimulating audio
            return self.state[1]  # reward = beta
        else:
            return -1  # bad action

    def is_done(self):
        return self.timestep >= 1000  # e.g., episode length
