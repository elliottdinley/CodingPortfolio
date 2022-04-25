from random import randint
import pygame
pygame.init()

WIDTH, HEIGHT = 400, 500
GRID_COLOUR = (187, 173, 160)
BG_COLOUR = (205, 193, 181)

TILE_COLOURS = {
    2: (238, 228, 218),
    4: (237, 224, 200),
    8: (242, 177, 121),
    16: (245, 149, 99),
    32: (246, 124, 95),
    64: (246, 94, 59),
    128: (237, 207, 114),
    256: (237, 204, 97),
    512: (237, 200, 80),
    1024: (237, 197, 63),
    2048: (237, 194, 46),
}

FONT_COLOUR = {
    0: (119, 110, 101),
    1: (249, 246, 242)
}

WIN = pygame.display.set_mode((WIDTH, HEIGHT))
pygame.display.set_caption("2048")
WIN.fill(BG_COLOUR)

SMALLFONT = pygame.font.Font("2048/ClearSans-Bold.ttf", 16)
LARGEFONT = pygame.font.Font("2048/ClearSans-Bold.ttf", 32)


board = [
    [0, 0, 0, 4],
    [0, 2, 0, 0],
    [0, 0, 0, 0],
    [0, 0, 0, 0]
]

def draw_grids():
    for y in range(4):
        for x in range(4):
            pygame.draw.rect(WIN, GRID_COLOUR, (x * 100, y * 100, 100, 100), 10)

def draw_tiles():
    for y in range(4):
        for x in range(4):
            current = board[y][x]
            if current != 0:
                if current > 2048:
                    pygame.draw.rect(WIN, (62, 57, 51), (x * 100 + 10, y * 100 + 10, 80, 80), 0)
                else:
                    pygame.draw.rect(WIN, TILE_COLOURS[current], (x * 100 + 10, y * 100 + 10, 80, 80), 0)
                if current > 4:
                    text = LARGEFONT.render(str(current), True, FONT_COLOUR[1])
                else:
                    text = LARGEFONT.render(str(current), True, FONT_COLOUR[0])
                
                text_rect = text.get_rect(center = (x * 100 + 50, y * 100 + 50))
                WIN.blit(text, text_rect)
            else:
                pygame.draw.rect(WIN, BG_COLOUR, (x * 100 + 10, y * 100 + 10, 80, 80), 0)

def draw_score(score, best):
    pygame.draw.rect(WIN, GRID_COLOUR, (50, 420, 80, 60), 0, 3)
    text = LARGEFONT.render(str(score), True, FONT_COLOUR[1])
    text_rect = text.get_rect(center = (90, 460))
    WIN.blit(text, text_rect)
    text = SMALLFONT.render("SCORE", True, FONT_COLOUR[1])
    text_rect = text.get_rect(center = (90, 435))
    WIN.blit(text, text_rect)



def move_tiles(direction):
    change = False
    if direction == 0 or direction == 3:
        for y in range(4):
            for x in range(4):
                if board[y][x] != 0:
                    current_tile = board[y][x]
                    if direction == 0: #up
                        for moveY in range(y - 1, -1, -1):
                            next_tile = board[moveY][x]
                            if current_tile == next_tile or next_tile == 0:
                                board[moveY + 1][x] = 0
                                board[moveY][x] += current_tile
                                change = True
                            else:
                                break
                    else: #left
                        for moveX in range(x - 1, -1, -1):
                            next_tile = board[y][moveX]
                            if current_tile == next_tile or next_tile == 0:
                                board[y][moveX + 1] = 0
                                board[y][moveX] += current_tile
                                change = True
                            else:
                                break
    else:
        for y in range(3, -1, -1):
            for x in range(3, -1, -1):
                if board[y][x] != 0:
                    current_tile = board[y][x]
                    if direction == 1: #right
                        for moveX in range(x + 1, 4):
                            next_tile = board[y][moveX]
                            if current_tile == next_tile or next_tile == 0:
                                board[y][moveX - 1] = 0
                                board[y][moveX] += current_tile
                                change = True
                            else:
                                break
                    else: #down
                        for moveY in range(y + 1, 4):
                            next_tile = board[moveY][x]
                            if current_tile == next_tile or next_tile == 0:
                                board[moveY - 1][x] = 0
                                board[moveY][x] += current_tile
                                change = True
                            else:
                                break
    if change:
        spawn_ran()

def spawn_ran():
    ran_tile = randint(1, 2) * 2
    while True:
        ran_X, ran_Y = randint(0, 3), randint(0, 3)
        if board[ran_Y][ran_X] == 0:
            board[ran_Y][ran_X] = ran_tile
            break

def main():
    running = True
    while running:
        draw_grids()
        draw_tiles()
        draw_score(0, 0)
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                running = False

            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_UP:
                    move_tiles(0)
                elif event.key == pygame.K_RIGHT:
                    move_tiles(1)
                elif event.key == pygame.K_DOWN:
                    move_tiles(2)
                elif event.key == pygame.K_LEFT:
                    move_tiles(3)
                
        pygame.display.update()

    pygame.quit()

main()
