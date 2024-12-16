function BurgerMenu(){
    console.log("Test");

    // const hamMenu = document.querySelector('.sidebarIcon');
    const offScreenMenuButton = document.querySelector('.BurgerButton');
    const offScreenMenuIcon = document.querySelector('.sidebarIcon');


    const offScreenMenu = document.querySelector('#sidebarMenu');
    const offScreenBackdrop = document.querySelector('#sidebarBackdrop')

    offScreenMenuButton.addEventListener('click', MenuOpen())

    function MenuOpen(){
        console.log("Meow")

        offScreenMenu.style.transform = 
        (offScreenMenu.style.transform == 'translateX(0px)') ? 'translateX(-250px)' : 'translateX(0px)'; 

        offScreenBackdrop.style.display = 
        (offScreenBackdrop.style.display == 'block') ? 'none' : 'block'; 

        offScreenMenuIcon.style.transform =
        (offScreenMenuIcon.style.transform == 'scale(0.5,0.5)') ? 'scale(1,1)' : 'scale(0.5,0.5)';
    }


}
