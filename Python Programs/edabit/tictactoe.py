class ttt:

    def __init__(self):
        self.grid = [[" " for i in range(3)] for j in range(3)]
        self.turn = "X"

    def drawboard(self):
        print(f" {self.grid[0][0]} | {self.grid[0][1]} | {self.grid[0][2]}")
        print("---+---+---")
        print(f" {self.grid[1][0]} | {self.grid[1][1]} | {self.grid[1][2]}")
        print("---+---+---")
        print(f" {self.grid[2][0]} | {self.grid[2][1]} | {self.grid[2][2]}")

    def place(self, x, y):
        if self.grid[y][x] != " ":
            print(f"There is a {self.grid[y][x]} at ({x}, {y})")
            input()
        else:
            self.grid[y][x] = self.turn
            if self.turn == "O":
                self.turn = "X"
            else:
                self.turn = "O"

    def detect(self):
        for i in range(3):
            if self.grid[i][0] == self.grid[i][1] == self.grid[i][2] != " ":
                return True, self.grid[i][0]
            if self.grid[0][i] == self.grid[1][i] == self.grid[2][i] != " ":
                return True, self.grid[0][i]

        if self.grid[0][0] == self.grid[1][1] == self.grid[2][2] != " ":
            return True, self.grid[0][0]
        if self.grid[0][2] == self.grid[1][1] == self.grid[2][0] != " ":
            return True, self.grid[0][0]

        return False, 0

tic = ttt()
while True:
    tic.drawboard()
    won, t = tic.detect()
    if won:
        print(f"{t} won!")
        break

    print(f"{tic.turn}'s turn")
    x = int(input("x >"))
    y = int(input("y >"))
    tic.place(x, y)
    print("\n"*5)
