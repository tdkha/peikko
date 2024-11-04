def get_layer_details(layer_name):
    print(f"\nEnter the {layer_name} layer details in mm: coordinates (X, Y), width (W), height (H), thickness (t):")
    x = int(input("X (mm): "))
    y = int(input("Y (mm): "))
    width = int(input("W (mm): "))
    height = int(input("H (mm): "))
    thickness = int(input("t (mm): "))
    return x, y, width, height, thickness

def calculate_center(x, y, width, height):
    center_x = x + width / 2
    center_y = y + height / 2
    return center_x, center_y

def validate_center_within_bounds(center_x, center_y, x, y, width, height):
    return (x <= center_x <= x + width) and (y <= center_y <= y + height)

def calculate_common_surface(x1, y1, width1, height1, x2, y2, width2, height2):
    insulation_x = max(x1, x2)
    insulation_y = max(y1, y2)
    insulation_width = min(x1 + width1, x2 + width2) - insulation_x
    insulation_height = min(y1 + height1, y2 + height2) - insulation_y
    return insulation_x, insulation_y, insulation_width, insulation_height

def get_hole_details():
    print("\nEnter the hole specifications in mm: coordinates (X₄, Y₄), width (W₄), height (H₄):")
    hole_x = int(input("X₄ (mm): "))
    hole_y = int(input("Y₄ (mm): "))
    hole_width = int(input("W₄ (mm): "))
    hole_height = int(input("H₄ (mm): "))
    return hole_x, hole_y, hole_width, hole_height

def calculate_overlap_area(layer_x, layer_y, layer_width, layer_height, hole_x, hole_y, hole_width, hole_height):
    overlap_x = max(layer_x, hole_x)
    overlap_y = max(layer_y, hole_y)
    overlap_width = max(0, min(layer_x + layer_width, hole_x + hole_width) - overlap_x)
    overlap_height = max(0, min(layer_y + layer_height, hole_y + hole_height) - overlap_y)
    overlap_area = (overlap_width * overlap_height) / 1_000_000  # Convert to square meters
    return overlap_area

def calculate_layer_properties(width, height, thickness, hole_area):
    surface_area = (width * height) / 1_000_000 - hole_area  # in m²
    volume = surface_area * thickness / 1000  # in m³
    weight_kg = volume * 2400  # kg
    weight_kn = weight_kg * 0.01  # kN
    return surface_area, volume, weight_kg, weight_kn

def main():
    # Internal layer details
    internal_x, internal_y, internal_width, internal_height, internal_thickness = get_layer_details("internal")
    internal_center_x, internal_center_y = calculate_center(internal_x, internal_y, internal_width, internal_height)
    print(f"\nInternal Layer Center: ({internal_center_x}, {internal_center_y})")

    # External layer details and ensure CG is within the internal layer
    while True:
        external_x, external_y, external_width, external_height, external_thickness = get_layer_details("external")
        external_center_x, external_center_y = calculate_center(external_x, external_y, external_width, external_height)
        print(f"\nExternal Layer Center: ({external_center_x}, {external_center_y})")

        if validate_center_within_bounds(external_center_x, external_center_y, internal_x, internal_y, internal_width, internal_height):
            print("The center of gravity of the external layer is within the internal layer.")
            break
        else:
            print("Error: The center of gravity of the external layer is outside the internal layer. Please adjust the dimensions.")

    # Common insulated layer
    insulation_x, insulation_y, insulation_width, insulation_height = calculate_common_surface(
        internal_x, internal_y, internal_width, internal_height, external_x, external_y, external_width, external_height)
    print(f"\nInsulated Layer Dimensions (Common Surface): Coordinates: ({insulation_x}, {insulation_y}), Width: {insulation_width} mm, Height: {insulation_height} mm")

    # Insulation thickness
    insulation_thickness = int(input("\nEnter the thickness of the insulation layer in mm (t₃): "))
    print(f"\nInsulation Layer Thickness: {insulation_thickness} mm")

    # Hole details and area overlap calculation
    while True:
        hole_x, hole_y, hole_width, hole_height = get_hole_details()
        hole_area_internal = calculate_overlap_area(internal_x, internal_y, internal_width, internal_height, hole_x, hole_y, hole_width, hole_height)
        hole_area_external = calculate_overlap_area(external_x, external_y, external_width, external_height, hole_x, hole_y, hole_width, hole_height)

        if hole_area_internal > 0 and hole_area_external > 0:
            print("The hole is located within both the internal and external layers.")
            break
        elif hole_area_internal > 0:
            print("The hole is located within the internal layer.")
            break
        elif hole_area_external > 0:
            print("The hole is located within the external layer.")
            break
        else:
            print("Error: The hole is outside both the internal and external layers. Please adjust the hole specifications.")

    # Internal layer properties
    internal_surface_area, internal_volume, internal_weight_kg, internal_weight_kn = calculate_layer_properties(
        internal_width, internal_height, internal_thickness, hole_area_internal)

    # External layer properties
    external_surface_area, external_volume, external_weight_kg, external_weight_kn = calculate_layer_properties(
        external_width, external_height, external_thickness, hole_area_external)

    # Print results
    print(f"\nSurface Area of Internal Layer: {internal_surface_area:.2f} m²")
    print(f"Surface Area of External Layer: {external_surface_area:.2f} m²")
    print(f"Volume of Internal Layer: {internal_volume:.2f} m³")
    print(f"Volume of External Layer: {external_volume:.2f} m³")
    print(f"Weight of Internal Layer: {internal_weight_kg:.2f} kg")
    print(f"Weight of External Layer: {external_weight_kg:.2f} kg")
    print(f"Weight of Internal Layer: {internal_weight_kn:.2f} kN")
    print(f"Weight of External Layer: {external_weight_kn:.2f} kN")

main()