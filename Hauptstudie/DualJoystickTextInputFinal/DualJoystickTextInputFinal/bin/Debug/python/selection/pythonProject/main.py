from InputManager import InputManager
import time
from pynput.keyboard import Key, Controller

wordLen = 5
joyStartPosCoordinate = 0.4
joyStartNegCoordinate = -0.4
joyPosLimit = 0.35
joyNegLimit = -0.35

inputs = InputManager(joyStartPosCoordinate, joyStartNegCoordinate, joyPosLimit, joyNegLimit)

side = 0
leftNeutral = False

rightNeutral = False

inputCheck = False

oldTime = time.perf_counter()
newTime = 0

oldTime2 = time.perf_counter()
newTime2 = 0

a = True
check = True
checkIn = False

keyboard = Controller()
keyboard.press(Key.ctrl)
keyboard.release(Key.ctrl)

#modes = [[Key.f1, Key.f2, Key.f3, Key.f4, Key.f5, Key.f6, Key.f7, Key.f8, Key.right], [Key.f9, Key.f10, Key.f11, Key.f12, Key.f13, Key.f14, Key.f15, Key.f16, Key.up]]
modes = [[Key.f3, Key.up, Key.f4, Key.right, Key.f1, Key.down, Key.f2, Key.left], [Key.f3, Key.up, Key.f4, Key.right, Key.f1, Key.down, Key.f2, Key.left]]
mode = 0
lsCheck = 0

def StringToKey(string):
    tmp = False
    global inputCheck
    global leftNeutral
    global rightNeutral
    global side
    neutral = False
    if string == "neutral":
        neutral = True
    elif string[-1] == 'L':
        side = 0
    else:
        side = 1
    string = string[:-1]
    if string == "leftUp":
        keyboard.press(modes[side][0])
        keyboard.release(modes[side][0])
        tmp = True
        inputCheck = True
    elif string == "up":
        keyboard.press(modes[side][1])
        keyboard.release(modes[side][1])
        tmp = True
        inputCheck = True
    elif string == "rightUp":
        keyboard.press(modes[side][2])
        keyboard.release(modes[side][2])
        tmp = True
        inputCheck = True
    elif string == "right":
        keyboard.press(modes[side][3])
        keyboard.release(modes[side][3])
        tmp = True
        inputCheck = True
    elif string == "rightDown":
        keyboard.press(modes[side][4])
        keyboard.release(modes[side][4])
        tmp = True
        inputCheck = True
    elif string == "down":
        keyboard.press(modes[side][5])
        keyboard.release(modes[side][5])
        tmp = True
        inputCheck = True
    elif string == "leftDown":
        keyboard.press(modes[side][6])
        keyboard.release(modes[side][6])
        tmp = True
        inputCheck = True
    elif string == "left":
        keyboard.press(modes[side][7])
        keyboard.release(modes[side][7])
        tmp = True
        inputCheck = True

    #if string == "neutral" and inputCheck:
    #    if side == 0:
    #        leftNeutral = True
    #        inputCheck = False
    #    elif side == 1:
    #        rightNeutral = True
    #        inputCheck = False
    #if neutral and inputCheck and side == 0:
    #    leftNeutral = True
    #    inputCheck = False
    #if neutral and inputCheck and side == 1:
    #    rightNeutral = True
    #    inputCheck = False



    #if tmp:
    #    if side == 0:
    #        leftNeutral = False
    #    elif side == 1:
    #        rightNeutral = False

while a:
    btns = inputs.getButtons()
    ls = inputs.getLS()
    if ls == "LS":
        if lsCheck == 0:
            keyboard.press(Key.f20)
            keyboard.release(Key.f20)
            print("press")
            lsCheck = 1
    elif ls != "LS":
        if lsCheck == 1:
            keyboard.press(Key.f19)
            keyboard.release(Key.f19)
            print("release")
            lsCheck = 0
    if btns == "A":
        print("A")
        keyboard.press(Key.f18)
        keyboard.release(Key.f18)
        newTime = 0
        oldTime = time.perf_counter()
        while newTime - oldTime < 0.4:
            newTime = time.perf_counter()
        oldTime = time.perf_counter()
    if btns == "START":
        print("START")
        keyboard.press(Key.f6)
        keyboard.release(Key.f6)
        newTime = 0
        oldTime = time.perf_counter()
        while newTime - oldTime < 0.4:
            newTime = time.perf_counter()
        oldTime = time.perf_counter()
    if btns == "Y":
        print("Y")
        keyboard.press(Key.f7)
        keyboard.release(Key.f7)
        newTime = 0
        oldTime = time.perf_counter()
        while newTime - oldTime < 0.4:
            newTime = time.perf_counter()
        oldTime = time.perf_counter()
    if btns == "RS":
        print("RS")
        #keyboard.press(Key.f17)
        #keyboard.release(Key.f17)
        #keyboard.press(Key.backspace)
        #keyboard.release(Key.backspace)
        #newTime = 0
        #oldTime = time.perf_counter()
        #while newTime - oldTime < 0.4:
        #    newTime = time.perf_counter()
        #oldTime = time.perf_counter()
    res = inputs.direction()
    if res is not None:
        newTime = 0
        newTime += time.perf_counter()
        if newTime - oldTime > 0.15:
            oldTime = 0
            oldTime += newTime
            StringToKey(res)
            check = True
            #if leftNeutral:
            #    keyboard.press(modes[0][8])
            #    keyboard.release(modes[0][8])
            #    #print("left mf")
            #    leftNeutral = False
            #    # inputCheck = [False, False]
            #if rightNeutral:
            #    keyboard.press(modes[1][8])
            #    keyboard.release(modes[1][8])
            #    #print("right mf")
            #    rightNeutral = False
        #StringToKey(res)
    #if check:
        #if inputs.restingRight():
        #    keyboard.press(Key.down)
        #    keyboard.release(Key.down)
            #check = False
    #if leftNeutral:
    #    keyboard.press(modes[0][8])
    #    keyboard.release(modes[0][8])
    #    print("left mf")
    #    leftNeutral = False
    #if rightNeutral:
    #    keyboard.press(modes[1][8])
    #    keyboard.release(modes[1][8])
    #    print("right mf")
    #    rightNeutral = False
    #newTime2 = time.perf_counter()
    #if (newTime2 - oldTime2 > 0.2) and inputs.getThumbStates()[0] and inputs.getThumbStates()[1]:
    #    oldTime2 = time.perf_counter()
    #    keyboard.press(modes[0][8])
    #    keyboard.release(modes[0][8])
    #    keyboard.press(modes[1][8])
    #    keyboard.release(modes[1][8])
    #    print("left mf")
    #    leftNeutral = False
    #    rightNeutral = False
