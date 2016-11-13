// JavaScript Document
// check for drag and drop support

// set images array
var images = [];
var piece = "";
var place = ""; 
for (i=0; i<6; i++) {
	j = i+1;
	images[i] = "puzzle-piece" + j + ".png"; 	
}
// randomize the pieces to display
images.sort(function() {return 0.5 - Math.random()});
for (i=0; i<6; i++) {
    $('#pieces').append("<img src=\"/Drag and Drop Puzzle_files/" + images[i] + "\" id=\"piece" + i + "\" draggable=true ondragstart=\"drag(this, event);\">");

	
	

}
// add drag and drop functions on the frame divs

function drag(draggableitem, e) {
	e.dataTransfer.setData("Text", draggableitem.id);	
}
function drop(target, e) {
	var id = e.dataTransfer.getData('Text');
	target.appendChild(document.getElementById(id));
	e.preventDefault();
}
