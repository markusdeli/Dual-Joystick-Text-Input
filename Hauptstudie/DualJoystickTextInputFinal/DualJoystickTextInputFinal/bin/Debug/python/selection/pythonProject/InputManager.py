from XInput import *
import time


class InputManager:
    posVal = 0.4
    negVal = -0.4
    posLim = 0.2
    negLim = -0.2

    neutralL = True
    neutralR = True

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

    @classmethod
    def isNeutral(cls, state, stick):
        if state[stick][0] < 0.1 and state[stick][0] > -0.1 and state[stick][1] < 0.1 and state[stick][1] > -0.1:
            return True
        else:
            return False

    def restingRight(self):
        state = get_thumb_values(get_state(user_index=0))
        if state[1][0] < 0.05 and state[1][1] < 0.05 and state[1][0] > -0.05 and state[1][1] > -0.05:
            return True
        return False

    def getLS(self):
        tmp = get_button_values(get_state(user_index=0))
        if tmp['LEFT_SHOULDER']:
            return"LS"

    def getButtons(self):
        tmp = get_button_values(get_state(user_index=0))
        if tmp['RIGHT_SHOULDER']:
            return "RS"
        elif tmp['A']:
            return "A"
        elif tmp['START']:
            return "START"
        elif tmp['Y']:
            return "Y"




    @classmethod
    def getDir(cls, state):
        if cls.leftUp(state, 0):
            #cls.neutralL = False
            return "leftUpL"
        elif cls.rightUp(state, 0):
            #cls.neutralL = False
            return "rightUpL"
        elif cls.leftDown(state, 0):
            #cls.neutralL = False
            return "leftDownL"
        elif cls.rightDown(state, 0):
            #cls.neutralL = False
            return "rightDownL"
        elif cls.left(state, 0):
            #cls.neutralL = False
            return "leftL"
        elif cls.right(state, 0):
            #cls.neutralL = False
            return "rightL"
        elif cls.up(state, 0):
            #cls.neutralL = False
            return "upL"
        elif cls.down(state, 0):
            #cls.neutralL = False
            return "downL"
        elif cls.leftUp(state, 1):
            #cls.neutralR = False
            return "leftUpR"
        elif cls.rightUp(state, 1):
            #cls.neutralR = False
            return "rightUpR"
        elif cls.leftDown(state, 1):
            #cls.neutralR = False
            return "leftDownR"
        elif cls.rightDown(state, 1):
            #cls.neutralR = False
            return "rightDownR"
        elif cls.left(state, 1):
            #cls.neutralR = False
            return "leftR"
        elif cls.right(state, 1):
            #cls.neutralR = False
            return "rightR"
        elif cls.up(state, 1):
            #cls.neutralR = False
            return "upR"
        elif cls.down(state, 1):
            #cls.neutralR = False
            return "downR"
        #elif cls.isNeutral(state, 0) and not cls.isNeutral(state, 1):
            #cls.neutralL = True
        #    return "neutralL"
        #elif cls.isNeutral(state, 1) and not cls.isNeutral(state, 0):
            #cls.neutralR = True
        #    return "neutralR"
        #elif cls.isNeutral(state, 0) and cls.isNeutral(state, 1):
            #cls.neutralL = True
            #cls.neutralR = True
        #    return "neutral"

    def direction(self):
        state = get_thumb_values(get_state(user_index=0))
        if state is not None:
            return self.getDir(state)
        return 0

    def buttons(self):
        ls, rs, a = self.getButtons(get_state(user_index=0))
        #if button is not None:
            #return button
        #return 0
        return ls, rs, a

    def getThumbStates(self):
        tmp = get_thumb_values(get_state(user_index=0))
        checkL = False
        checkR = False
        if tmp[0][0] < 0.1 and tmp[0][0] > -0.1 and tmp[0][1] < 0.1 and tmp[0][1] > -0.1 :
            checkL = True
        if tmp[1][0] < 0.1 and tmp[1][0] > -0.1 and tmp[1][1] < 0.1 and tmp[1][1] > -0.1 :
            checkR = True

        return checkL, checkR