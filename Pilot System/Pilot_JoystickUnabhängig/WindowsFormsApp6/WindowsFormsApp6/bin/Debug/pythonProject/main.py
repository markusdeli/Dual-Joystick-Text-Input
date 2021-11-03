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
check = True

keyboard = Controller()
keyboard.press(Key.ctrl)
keyboard.release(Key.ctrl)

modes = [[Key.f1, Key.f2, Key.f3, Key.f4, Key.f5, Key.f6, Key.f7, Key.f8], [Key.f9, Key.f10, Key.f11, Key.f12, Key.f13, Key.f14, Key.f15, Key.f16]]
mode = 0
lsCheck = 0

while a:
    btn = inputs.getButtons()
    if btn == "LS":
        #mode = 1
        #if mode != 1:
        if lsCheck == 0:
            keyboard.press(Key.f20)
            keyboard.release(Key.f20)
            print("press")
            lsCheck = 1
    elif btn != "LS":
        if lsCheck == 1:
            keyboard.press(Key.f19)
            keyboard.release(Key.f19)
            print("release")
            lsCheck = 0
    if btn == "A":
        print("A")
        keyboard.press(Key.f18)
        keyboard.release(Key.f18)
        newTime = 0
        oldTime = time.perf_counter()
        while newTime - oldTime < 0.4:
            newTime = time.perf_counter()
        oldTime = time.perf_counter()
    if btn == "RS":
        print("RS")
        keyboard.press(Key.f17)
        keyboard.release(Key.f17)
        newTime = 0
        oldTime = time.perf_counter()
        while newTime - oldTime < 0.15:
            newTime = time.perf_counter()
        oldTime = time.perf_counter()
    res = inputs.direction()
    if res is not None:
        newTime = 0
        newTime += time.perf_counter()
        if newTime - oldTime > 0.25:
            oldTime = 0
            oldTime += newTime
            StringToKey(res)
            check = True
    if check:
        if inputs.restingRight():
            keyboard.press(Key.down)
            keyboard.release(Key.down)
            check = False

    def StringToKey(string):
        if string[-1] == 'L':
            side = 0
        else:
            side = 1
        string = string[:-1]
        if string == "leftUp":
            keyboard.press(modes[side][0])
            keyboard.release(modes[side][0])

        elif string == "up":
            keyboard.press(modes[side][1])
            keyboard.release(modes[side][1])
        elif string == "rightUp":
            keyboard.press(modes[side][2])
            keyboard.release(modes[side][2])
        elif string == "right":
            keyboard.press(modes[side][3])
            keyboard.release(modes[side][3])
        elif string == "rightDown":
            keyboard.press(modes[side][4])
            keyboard.release(modes[side][4])
        elif string == "down":
            keyboard.press(modes[side][5])
            keyboard.release(modes[side][5])
        elif string == "leftDown":
            keyboard.press(modes[side][6])
            keyboard.release(modes[side][6])
        elif string == "left":
            keyboard.press(modes[side][7])
            keyboard.release(modes[side][7])
