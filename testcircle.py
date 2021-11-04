from circle import *


if __name__ == '__main__':


    circle = CircularLL()
    
    circle.insert_item(3)
    circle.insert_item(4)
    circle.insert_item(2)
    circle.insert_item(1)
    print(circle)

    circle.delete_item(3)
    circle.delete_item(2)
    print(circle)
