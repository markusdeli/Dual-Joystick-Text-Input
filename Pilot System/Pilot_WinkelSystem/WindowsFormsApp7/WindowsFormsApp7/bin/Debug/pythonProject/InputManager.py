from XInput import *
import time


class InputManager:
    posVal = 0.4
    negVal = -0.4
    posLim = 0.2
    negLim = -0.2

    def __init__(self, pos, neg, posLi, negLi):
        self.posVal = pos
        self.negVal = neg

        self.posLim = posLi
        self.negLim = negLi

    '''
    @classmethod
    def left(cls, state, stick):
        if state[stick][0] < cls.negVal:
            return True
        else:
            return False

    @classmethod
    def right(cls, state, stick):
        if state[stick][0] > cls.posVal:
            return True
        else:
            return False
    @classmethod
    def up(cls, state, stick):
        if state[stick][1] > cls.posVal:
            return True
        else:
            return False
    @classmethod
    def down(cls, state, stick):
        if state[stick][1] < cls.negVal:
            return True
        else:
            return False
    @classmethod
    def leftUp(cls, state, stick):
        if cls.left(state, stick) and cls.up(state, stick):
            return True
        else:
            return False
    @classmethod
    def rightUp(cls, state, stick):
        if cls.right(state, stick) and cls.up(state, stick):
            return True
        else:
            return False
    @classmethod
    def leftDown(cls, state, stick):
        if cls.left(state, stick) and cls.down(state, stick):
            return True
        else:
            return False
    @classmethod
    def rightDown(cls, state, stick):
        if cls.right(state, stick) and cls.down(state, stick):
            return True
        else:
            return False
    '''

    @classmethod
    def left(cls, state, stick):
        if state[stick][0] < cls.negVal and state[stick][1] < cls.posLim and state[stick][1] > cls.negLim:
            return True
        else:
            return False

    @classmethod
    def right(cls, state, stick):
        if state[stick][0] > cls.posVal and state[stick][1] < cls.posLim and state[stick][1] > cls.negLim:
            return True
        else:
            return False

    @classmethod
    def up(cls, state, stick):
        if state[stick][1] > cls.posVal and state[stick][0] < cls.posLim and state[stick][0] > cls.negLim:
            return True
        else:
            return False

    @classmethod
    def down(cls, state, stick):
        if state[stick][1] < cls.negVal and state[stick][0] < cls.posLim and state[stick][0] > cls.negLim:
            return True
        else:
            return False

    @classmethod
    def leftUp(cls, state, stick):
        if state[stick][0] < cls.negVal and state[stick][1] > cls.posVal and cls.up(state, stick) == False and cls.left(state,
                                                                                                        stick) == False:
            return True
        else:
            return False

    @classmethod
    def rightUp(cls, state, stick):
        if state[stick][0] > cls.posVal and state[stick][1] > cls.posVal and cls.up(state, stick) == False and cls.right(state,
                                                                                                         stick) == False:
            return True
        else:
            return False

    @classmethod
    def leftDown(cls, state, stick):
        if state[stick][0] < cls.negVal and state[stick][1] < cls.negVal and cls.down(state, stick) == False and cls.left(state,
                                                                                                          stick) == False:
            return True
        else:
            return False

    @classmethod
    def rightDown(cls, state, stick):
        if state[stick][0] > cls.posVal and state[stick][1] < cls.negVal and cls.down(state, stick) == False and cls.right(state,
                                                                                                           stick) == False:
            return True
        else:
            return False


    def restingRight(self):
        state = get_thumb_values(get_state(user_index=0))
        if state[1][0] < 0.2 and state[1][1] < 0.2 and state[1][0] > -0.2 and state[1][1] > -0.2:
            return True
        return False

    #@classmethod
    #def getButtons(cls, state):
    #    if EVENT_BUTTON_PRESSED == 3:
    #        button = get_button_values(state)
    #        if button["A"]:
    #            return "A"
    #        elif button["B"]:
    #            return "B"
    #        elif button["X"]:
    #            return "X"
    #        elif button["Y"]:
    #            return "Y"
    #        elif button["LEFT_THUMB"]:
    #            return "LT"
    #        elif button["RIGHT_THUMB"]:
    #            return "RT"
    #        elif button["LEFT_SHOULDER"]:
    #            return "LS"
    #        elif button["RIGHT_SHOULDER"]:
    #            return "RS"
    #        elif button["START"]:
    #            return "START"
    #        elif button["BACK"]:
    #            return "BACK"
    #    if EVENT_BUTTON_RELEASED == 4:
    #        button = get_button_values(state)
    #        if button['LEFT_SHOULDER']:
    #            return "LSR"


    def getButtons(self):
        events = get_events()
        for event in events:
            if event.type == EVENT_BUTTON_PRESSED:
                if event.button == "LEFT_SHOULDER":
                    return "LS"
                if event.button == "RIGHT_SHOULDER":
                    return "RS"
                elif event.button == "A":
                    return "A"




    @classmethod
    def getDir(cls, state):
        if cls.leftUp(state, 0):
            return "leftUpL"
        elif cls.rightUp(state, 0):
            return "rightUpL"
        elif cls.leftDown(state, 0):
            return "leftDownL"
        elif cls.rightDown(state, 0):
            return "rightDownL"
        elif cls.left(state, 0):
            return "leftL"
        elif cls.right(state, 0):
            return "rightL"
        elif cls.up(state, 0):
            return "upL"
        elif cls.down(state, 0):
            return "downL"
        elif cls.leftUp(state, 1):
            return "leftUpR"
        elif cls.rightUp(state, 1):
            return "rightUpR"
        elif cls.leftDown(state, 1):
            return "leftDownR"
        elif cls.rightDown(state, 1):
            return "rightDownR"
        elif cls.left(state, 1):
            return "leftR"
        elif cls.right(state, 1):
            return "rightR"
        elif cls.up(state, 1):
            return "upR"
        elif cls.down(state, 1):
            return "downR"



    def direction(self):
        state = get_thumb_values(get_state(user_index=0))
        if state is not None:
            return self.getDir(state)
        return 0

    def buttons(self):
        button = self.getButtons(get_state(user_index=0))
        #if button is not None:
            #return button
        #return 0
        return button
