extends Control

### FILE PATHS ARE NOT CASE SENSITIVE yes

var user = {"username": "", 
			"file": "",
			"data": ""}

func _ready():
	pass
	#for key in user.values():
	#	print(key)
	#print(user.keys())

func setup():
	var new_file = File.new()
	
	if new_file.file_exists(user["file"]):
		new_file.open(user.get("file"), File.READ)
		var content = new_file.get_as_text()
		user["data"] = content
		new_file.close()
		print("test")
	else:
		new_file.open(user["file"], File.WRITE)
		new_file.store_string("")
		new_file.close()
		#print_debug("No file existed with the name of: " + user["file"])
		print_stack()
	

func _on_CreateUserButton_pressed():
	user["username"] = $UsernameInput.text
	user["file"] = "user://" + user["username"] + ".txt"
	#print(user["username"])
	#print(user["file"])
	setup()
