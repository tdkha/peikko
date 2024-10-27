def main():
    # internal layer details
    print("Enter the internal layer details in mm: coordinates (X₁, Y₁), width (W₁), height (H₁), thickness (t₁):")
    internal_x = int(input("X₁ (mm): "))
    internal_y = int(input("Y₁ (mm): "))
    internal_width = int(input("W₁ (mm): "))
    internal_height = int(input("H₁ (mm): "))
    internal_thickness = int(input("t₁ (mm): "))
    
    # center coordinates of the internal layer
    internal_center_x = internal_x + internal_width / 2
    internal_center_y = internal_y + internal_height / 2
    print(f"\nInternal Layer Center: ({internal_center_x}, {internal_center_y})")

    # external layer details and ensure CG is within the internal layer
    while True:
        print("\nEnter the external layer details in mm: coordinates (X₂, Y₂), width (W₂), height (H₂), thickness (t₂):")
        external_x = int(input("X₂ (mm): "))
        external_y = int(input("Y₂ (mm): "))
        external_width = int(input("W₂ (mm): "))
        external_height = int(input("H₂ (mm): "))
        external_thickness = int(input("t₂ (mm): "))
        
        #center coordinates of the external layer
        external_center_x = external_x + external_width / 2
        external_center_y = external_y + external_height / 2
        print(f"\nExternal Layer Center: ({external_center_x}, {external_center_y})")
        
        # Check if the external layer's center is within the internal layer
        if (internal_x <= external_center_x <= internal_x + internal_width) and (internal_y <= external_center_y <= internal_y + internal_height):
            print("The center of gravity of the external layer is within the internal layer.")
            break  # Exit the loop if CG is within bounds
        else:
            print("Error: The center of gravity of the external layer is outside the internal layer. Please adjust the dimensions.")

    # dimensions of the insulated layer as the common surface between internal and external layers
    insulation_x = max(internal_x, external_x)
    insulation_y = max(internal_y, external_y)
    insulation_width = min(internal_x + internal_width, external_x + external_width) - insulation_x
    insulation_height = min(internal_y + internal_height, external_y + external_height) - insulation_y

    print(f"\nInsulated Layer Dimensions (Common Surface):")
    print(f"Coordinates: ({insulation_x}, {insulation_y}), Width: {insulation_width} mm, Height: {insulation_height} mm")

    # insulation layer thickness (t₃)
    print("\nEnter the thickness of the insulation layer in mm (t₃):")
    insulation_thickness = int(input("t₃ (mm): "))
    print(f"\nInsulation Layer Thickness: {insulation_thickness} mm")

    # hole specifications and check location
    while True:
        print("\nEnter the hole specifications in mm: coordinates (X₄, Y₄), width (W₄), height (H₄):")
        hole_x = int(input("X₄ (mm): "))
        hole_y = int(input("Y₄ (mm): "))
        hole_width = int(input("W₄ (mm): "))
        hole_height = int(input("H₄ (mm): "))
        print(f"\nHole Specifications:\nCoordinates: ({hole_x}, {hole_y}), Width: {hole_width} mm, Height: {hole_height} mm")
        
        #  hole boundaries
        hole_right = hole_x + hole_width
        hole_top = hole_y + hole_height

        # Check if the hole is within the internal layer
        in_internal_layer = (internal_x <= hole_x <= internal_x + internal_width) and \
                            (internal_x <= hole_right <= internal_x + internal_width) and \
                            (internal_y <= hole_y <= internal_y + internal_height) and \
                            (internal_y <= hole_top <= internal_y + internal_height)

        # Check if the hole is within the external layer
        in_external_layer = (external_x <= hole_x <= external_x + external_width) and \
                            (external_x <= hole_right <= external_x + external_width) and \
                            (external_y <= hole_y <= external_y + external_height) and \
                            (external_y <= hole_top <= external_y + external_height)

        # Determine placement
        if in_internal_layer and in_external_layer:
            print("The hole is located within both the internal and external layers.")
            break  # Exit loop if valid
        elif in_internal_layer:
            print("The hole is located within the internal layer.")
            break  # Exit loop if valid
        elif in_external_layer:
            print("The hole is located within the external layer.")
            break  # Exit loop if valid
        else:
            print("Error: The hole is outside both the internal and external layers. Please adjust the hole specifications.")

main()
