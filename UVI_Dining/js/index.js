var slideIndex = 0;
carousel();

function carousel() {
  var i;
  var x = document.getElementsByClassName("picslides");
  for (i = 0; i < x.length; i++) {
    x[i].style.display = "none";
  }
  slideIndex++;
  if (slideIndex > x.length) {
    slideIndex = 1
  }
  x[slideIndex - 1].style.display = "block";
  setTimeout(carousel, 5000); // Change image every 5 seconds
}



var picsindex = 1;
showpics(picsindex);

function plusPics(n) {
  showpics(picsindex += n);
}

function currentPics(n) {
  showpics(picsindex = n);
  
}


function showpics(n) {
  var i;
  var pics = document.getElementsByClassName("picslides");
  var dots = document.getElementsByClassName("dot");
  
  if (n > pics.length) {picsindex = 1}    
  if (n < 1) {picsindex = pics.length}
  for (i = 0; i < pics.length; i++) {
      pics[i].style.display = "none";  
  }
  for (i = 0; i < dots.length; i++) {
      dots[i].className = dots[i].className.replace(" active", "");
  }
  pics[picsindex-1].style.display = "block";  
  dots[picsindex-1].className += " active";

 
}


var mc = new Hammer(mySlides);


mc.on("swipeleft swiperight", function(ev) {
  if (ev.type =="swipeleft"){
   
    document.getElementById('a-next').click();
 
  }
  if (ev.type =="swiperight"){
   
    document.getElementById('a-prev').click();
 
  }
});
