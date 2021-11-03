from InputManager import InputManager
import time
from pynput.keyboard import Key, Controller

wordLen = 5
joyStartPosCoordinate = 0.4
joyStartNegCoordinate = -0.4
joyPosLimit = 0.35
joyNegLimit = -0.35

inputs = InputManager(joyStartPosCoordinate, joyStartNegCoordinate, joyPosLimit, joyNegLimit)


oldTime = time.perf_counter()
newTime = 0

a = True

keyboard = Controller()
keyboard.press(Key.ctrl)
keyboard.release(Key.ctrl)

modes = [[['A', 'A'], ['B', 'B'], ['C', 'C'], ['D', 'D'], ['E', 'E'], ['F', 'F'], ['G', 'G'], ['H', 'H']], [['I', 'I'], ['J', 'J'], ['K', 'K'], ['L', 'L'], ['M', 'M'], ['N', 'N'], ['O', 'O'], ['P', 'P']]]
mode = 0

while a:
    btn = inputs.buttons()
    if btn == "RS":
        mode = 1
        if mode != 1:
            keyboard.press(Key.alt)
            keyboard.release(Key.alt)
    else:
        mode = 0
        if mode != 0:
            keyboard.press(Key.ctrl)
            keyboard.release(Key.ctrl)
    res = inputs.direction()
    if res is not None:
        newTime = 0
        newTime += time.perf_counter()
        if newTime - oldTime > 0.4:
            oldTime = 0
            oldTime += newTime
            StringToKey(res)

    def StringToKey(string):
        if string[-1] == 'L':
            side = 0
        else:
            side = 1
        string = string[:-1]
        if string == "leftUp":
            keyboard.press(modes[side][0][mode])
            keyboard.release(modes[side][0][mode])
        elif string == "up":
            keyboard.press(modes[side][1][mode])
            keyboard.release(modes[side][1][mode])
        elif string == "rightUp":
            keyboard.press(modes[side][2][mode])
            keyboard.release(modes[side][2][mode])
        elif string == "right":
            keyboard.press(modes[side][3][mode])
            keyboard.release(modes[side][3][mode])
        elif string == "rightDown":
            keyboard.press(modes[side][4][mode])
            keyboard.release(modes[side][4][mode])
        elif string == "down":
            keyboard.press(modes[side][5][mode])
            keyboard.release(modes[side][5][mode])
        elif string == "leftDown":
            keyboard.press(modes[side][6][mode])
            keyboard.release(modes[side][6][mode])
        elif string == "left":
            keyboard.press(modes[side][7][mode])
            keyboard.release(modes[side][7][mode])
