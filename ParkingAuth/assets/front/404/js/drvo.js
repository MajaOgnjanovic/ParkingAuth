function prikazi_lisce(){
    document.getElementById('prikazi').classList.add("crtanje");
     document.getElementById('prikazi').addEventListener("animationend",function(){
         document.getElementById('prikazi').classList.remove("crtanje");
     });
    document.getElementById('prikazi').style.display='block';
 }
 function sakri_lisce(){
    document.getElementById('prikazi').style.display='none';
  }