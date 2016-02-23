
This package contains a scene for the selection of the current avatar.

Integration steps.

1) Open AvatarCreation.scene
2) Look for the AvatarPool GameObject and its AvatarPool Component,
3) In it there are 4 lists, one for each combination of Teacher/Student and Male/Female.
4) Create race categories on each list(Black/Hispanic/etc)
	a) Use the '+' button  to create a new race category
	b) To rename a category edit the name field, '(Race)'
	c) Drag and drop races to reorder as needed. This is the order they will appear in on the editor.
5) Add avatar models to each race
	a) Use the '+' button within the race category to create new avatar slots
	b) Drag and drop model prefabs into the slots.
	c) Drag and drop avatars to reorder as needed. This is the order they will appear in on the editor.


The Save UI button saves the current state of the editor and the project path to the currently selected avatar. 
This can be retrieved from PlayerPrefs with the key value "AvatarPath"