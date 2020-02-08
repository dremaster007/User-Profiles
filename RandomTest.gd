extends Node

var array = ["Tony", "Jeff", "Karen", "Jimmy"]

var RNG = RandomNumberGenerator.new()

func _ready():
	RNG.randomize()
	print(RNG.get_seed())
	var i = RNG.randi() % 4
	print(array[i])

#func _input(event):
#	if event.is_action("ui_select"):
#		var i = randi() % 4
#		print(i)