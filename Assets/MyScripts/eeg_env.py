import numpy as np

class EEGEnv:
    def __init__(self, target_ratios):
        self.state = np.zeros(5)  # alpha, beta, delta, theta, gamma
        self.timestep = 0
        self.prev_ratios = np.zeros(5)
        self.target_ratios = np.array(target_ratios)

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

    def get_current_ratios(self):
        total = np.sum(self.state) + 1e-6
        return self.state / total

    def get_reward(self, action):
        current_ratios = self.get_current_ratios()
        curr_distance = np.linalg.norm(current_ratios - self.target_ratios)
        prev_distance = np.linalg.norm(self.prev_ratios - self.target_ratios)
        reward = prev_distance - curr_distance

        self.prev_ratios = current_ratios
        return reward

    def is_done(self):
        return self.timestep >= 1000
