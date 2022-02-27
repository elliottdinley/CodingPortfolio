from ast import Num
import random
class bagels:

    def __init__(self):
        self.guessno = 19
        digit1 = str(random.randint(0, 9))
        digit2 = str(random.randint(0, 9))
        while digit1 == digit2:
            digit2 = str(random.randint(0, 9))
        digit3 = str(random.randint(0, 9))
        while digit3 in {digit1, digit2}:
            digit3 = str(random.randint(0, 9))
        self.number = "".join([digit1, digit2, digit3])

    def guessnumber(self, guess):
        if self.guessno == 0:
            print(f"Failed! The number was {self.number}")
            return True
        if guess == self.number:
            print("Well Done! Number guessed")
            return True
        for i in range(3):
            if self.number.__contains__(guess[i]):
                if self.number[i] == guess[i]:
                    print("PICO", end = " ")
                else:
                    print("FERMI", end = " ")
        print("\n")
        self.guessno -= 1
        return False

playagain = True
while playagain:
    game = bagels()
    while True:
        if game.guessnumber(input(f"Guess {game.guessno + 1}:\nGuess >")):
            break
    if input("Play again> [y/n]").upper() == "N":
        playagain = False
