import random

class aceydeucey:

    def __init__(self, money):
        self.card1 = self.randomcard()
        self.card2 = self.randomcard()
        self.playercard = self.randomcard()
        self.pot = money

    def randomcard(self, basecard = 0, hl = -1):
        ranno = random.randrange(1, 13)
        if hl == 0:
            print("The dealer has decided the next card will be higher")
            while ranno < basecard:
                ranno = random.randrange(1, 13)
            return ranno
        if hl == 1:
            print("The dealer has decided the next card will be lower")
            while ranno > basecard:
                ranno = random.randrange(1, 13)
        return ranno

    def displaycard(self, card):
        if card == 1:
            return "an ace"
        if 2 <= card <= 10:
            if card == 8:
                return f"an {card}"
            else:
                return f"a {card}"
        if card == 11:
            return "a Jack"
        if card == 12:
            return "a Queen"
        if card == 13:
            return "a King"

    def gamewon(self):
        if self.card1 <= self.playercard <= self.card2:
            return True
        return False

playagain = True
money = 100

while playagain:
    game = aceydeucey(money)
    print(f"Pot amount: {game.pot}")
    while True:
        bet = int(input("Enter bet >"))
        if bet <= game.pot:
            break
        print("Unsufficient funds!")

    print(f"The dealer deals {game.displaycard(game.card1)} ({game.card1}) and {game.displaycard(game.card2)} ({game.card2})")
    
    if game.card1 == game.card2:
        print("The cards match! Your bet is doubled")
        game.card2 = game.randomcard(game.card1, random.randint(0, 1))
        print(f"The dealer deals {game.displaycard(game.card1)} ({game.card1}) and {game.displaycard(game.card2)} ({game.card2})")
        
    if game.gamewon():
        print("You Won!")
    else:
        print("You Lost!")
        money -= bet

    print(f"Your card was {game.displaycard(game.playercard)} ({game.playercard})")

    if input("Play again? [y/n] >") == "n":
        break
    elif money <= 0:
        print("Unsufficient funds! Cannot play again")
        break

    print()
