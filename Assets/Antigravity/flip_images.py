from PIL import Image
import os

# Path to the Pictures folder
pictures_dir = r"c:\UnityProjects\Tompedia\Tompedia_2DMario\Assets\Project\Pictures"

# Image files to flip
image_files = ["Arms_and_Legs.png", "Arms_and_Legs_Left.png"]

for image_file in image_files:
    image_path = os.path.join(pictures_dir, image_file)
    
    # Open the image
    img = Image.open(image_path)
    
    # Flip horizontally (left-right)
    flipped_img = img.transpose(Image.FLIP_LEFT_RIGHT)
    
    # Save the flipped image (overwrite)
    flipped_img.save(image_path)
    
    print(f"Flipped: {image_file}")

print("All specified images have been flipped!")
