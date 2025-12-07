from PIL import Image
import os

# Path to the Pictures folder
pictures_dir = r"c:\UnityProjects\Tompedia\Tompedia_2DMario\Assets\Project\Pictures"

# List of image files to flip
image_files = ["Arms_and_Legs.png", "Head_and_Body.png"]

for image_file in image_files:
    image_path = os.path.join(pictures_dir, image_file)
    
    # Open the original image
    img = Image.open(image_path)
    
    # Flip horizontally (left-right)
    flipped_img = img.transpose(Image.FLIP_LEFT_RIGHT)
    
    # Create new filename with "Left" suffix
    name_without_ext = os.path.splitext(image_file)[0]
    ext = os.path.splitext(image_file)[1]
    new_filename = f"{name_without_ext}_Left{ext}"
    new_path = os.path.join(pictures_dir, new_filename)
    
    # Save the flipped image as a new file
    flipped_img.save(new_path)
    
    print(f"Created flipped version: {new_filename}")

print("All flipped images have been saved as new files!")
