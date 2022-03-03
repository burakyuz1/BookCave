var x=0;
var inputPrice=document.getElementById("inputPrice");
inputPrice.oninput=function(){
  labelPrice.textContent=this.value;
  x=parseInt(this.value);
  
}
