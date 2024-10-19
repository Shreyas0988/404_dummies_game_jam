from ursina import *
from ursina.prefabs.first_person_controller import FirstPersonController

app = Ursina()

# Create a custom cursor entity
custom_cursor = Entity(model='quad', scale=.05, texture='cursor.png')

for i in range(10):
    for j in range(10):
        Entity(model="cube",
               color=color.dark_gray,
               collider="box",
               ignore=True,
               position=(j, 0, i),
               parent=scene,
               origin_y=0.5,
               texture="white_cube")

class TextureBox(Button):
    def __init__(self, position=(5, 2, 5)):
        super().__init__(parent=scene,
                         position=position,
                         model="cube",
                         origin_y=0.5,
                         texture="dirt.png",
                         color=color.color(0, 0, 1))
        self.texture_choice = 0
        self.textures = ['dirt.png', 'table.png', 'iron.png', 'stone.png']

    def input(self, key):
        if self.hovered:
            if key == 'left mouse down':
                self.texture_choice += 1
                self.texture_choice %= len(self.textures)
                self.texture = self.textures[self.texture_choice]

TextureBox()
player = FirstPersonController()

def update():
    # Update the position of the custom cursor to match the mouse position
    custom_cursor.position = Vec3(mouse.x, mouse.y, -1)

app.run()
