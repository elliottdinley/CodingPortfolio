class oware:

    def __init__(self):
        self.houses = [4] * 12
        self.selection = -1

    def display(self):
        print("|A|B|C|D|E|F|")
        print("+-+-+-+-+-+-+")
        print("|", end = "")
        for i in range(6):
            print(self.houses[i], end = "|")

        print("\n\n|", end = "")
        for i in range (11, 5, -1):
            print(self.houses[i], end = "|")
        print("\n+-+-+-+-+-+-+")
        print("|6|5|4|3|2|1|")

    def sowing(self, player):
        # select house
        if player == 1:
            while True:
                selection = input("Player 1:\nHouse Number >").upper()
                if selection == "A":
                    selection = 0
                elif selection == "B":
                    selection = 1
                elif selection == "C":
                    selection = 2
                elif selection == "D":
                    selection = 3
                elif selection == "E":
                    selection = 4
                elif selection == "F":
                    selection = 5
                
                if selection != -1:
                    break

        elif player == 2:
            selection = int(input("Player 2:\nHouse Number >"))
            selection += 5

        #distribute seeds
        index = selection - 1
        for i in range(self.houses[selection]):
            if index == -1:
                index = 11

            self.houses[index] += 1
            index -= 1
        self.houses[selection] = 0

    def capturing(self): #######


game = oware()
turn = 1

while True:
    game.display()
    game.sowing(turn)

    if turn == 1:
        turn = 2
    else:
        turn = 1
