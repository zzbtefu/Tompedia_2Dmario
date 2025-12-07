from PIL import Image
import os

# Path to the Pictures folder
pictures_dir = r"c:\UnityProjects\Tompedia\Tompedia_2DMario\Assets\Project\Pictures"

# Image file to flip
image_file = "Head_and_Body_Left.png"
image_path = os.path.join(pictures_dir, image_file)

# Open the original image
img = Image.open(image_path)

# Flip horizontally (left-right)
flipped_img = img.transpose(Image.FLIP_LEFT_RIGHT)

# Save the flipped image, overwriting the original
flipped_img.save(image_path)

print(f"Flipped {image_file} horizontally!")
