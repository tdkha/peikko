"""
------------------------------------------------------------------------------------------------------
 ________  ________  ___       ________  ___  ___  ___       ________  _________  ________  ________     
|\   ____\|\   __  \|\  \     |\   ____\|\  \|\  \|\  \     |\   __  \|\___   ___\\   __  \|\   __  \    
\ \  \___|\ \  \|\  \ \  \    \ \  \___|\ \  \\\  \ \  \    \ \  \|\  \|___ \  \_\ \  \|\  \ \  \|\  \   
 \ \  \    \ \   __  \ \  \    \ \  \    \ \  \\\  \ \  \    \ \   __  \   \ \  \ \ \  \\\  \ \   _  _\  
  \ \  \____\ \  \ \  \ \  \____\ \  \____\ \  \\\  \ \  \____\ \  \ \  \   \ \  \ \ \  \\\  \ \  \\  \| 
   \ \_______\ \__\ \__\ \_______\ \_______\ \_______\ \_______\ \__\ \__\   \ \__\ \ \_______\ \__\\ _\ 
    \|_______|\|__|\|__|\|_______|\|_______|\|_______|\|_______|\|__|\|__|    \|__|  \|_______|\|__|\|__|
------------------------------------------------------------------------------------------------------
Code Convention:
	-	Indentation:	use Tab instead of Spaces. Check the lower right corner of VsCode.
	-	Variable:		camelCase (uppercase from the second word) 
"""


"""
-------------------------------------------------------------------------------------
Class for a single component
-------------------------------------------------------------------------------------
"""
class Component:
	def __init__(self, x: int, y: int, width: int, height: int, thickness: int):
		self.x = x
		self.y = y
		self.width = width
		self.height = height
		self.thickness = thickness

"""
-------------------------------------------------------------------------------------
Class for input data containing layers(components)
-------------------------------------------------------------------------------------
"""
class ComputingData:
	def __init__(self, external_layer: Component, internal_layer: Component, insulated_layer: Component, hole: Component):
		self.external_layer = external_layer
		self.internal_layer = internal_layer
		self.insulated_layer = insulated_layer
		self.hole = hole

"""
-------------------------------------------------------------------------------------
Function to validate the dimensions of the layers in the ComputingData object.
-------------------------------------------------------------------------------------
"""
def is_valid(data: ComputingData) -> bool:
	# Start here
	if (data.external_layer.width <= 0 or data.external_layer.height <= 0 or
		data.internal_layer.width <= 0 or data.internal_layer.height <= 0 or
		data.insulated_layer.width <= 0 or data.insulated_layer.height <= 0 or
		data.hole.width <= 0 or data.hole.height <= 0):
		return False
	return True


"""
-------------------------------------------------------------------------------------
Main function to test your functionalities.
-------------------------------------------------------------------------------------
"""
def main():
	# Create component instances
	external_layer = Component(0, 0, 100, 200, 10)
	internal_layer = Component(0, 0, 90, 190, 8)
	insulated_layer = Component(0, 0, 85, 180, 6)
	hole = Component(10, 10, 20, 20, 2)

	# Create ComputingData instance
	computing_data = ComputingData(external_layer, internal_layer, insulated_layer, hole)

	# Validate data
	if is_valid(computing_data):
		print("Data is valid. Start computing.")
	else:
		print("Data is invalid. Please check the input values.")


if __name__ == "__main__":
	main()
