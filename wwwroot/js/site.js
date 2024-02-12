function toggleMenu() {
    var mobileMenu = document.getElementById('mobile-menu');
    mobileMenu.classList.toggle('closed');
}

function closeMenu() {
    var mobileMenu = document.getElementById('mobile-menu');
    mobileMenu.classList.add('closed');
}

// Hämta den aktuella sidan från URL-en
var currentPage = window.location.pathname.split('/').pop();

// Hämta alla länkar i navigationsmenyn
var navLinks = document.querySelectorAll('.navbar-nav a');

// Loopa igenom varje länk och lägg till klassen 'active' om dess href matchar den aktuella sidan
navLinks.forEach(function(link) {
    var linkPage = link.getAttribute('href').split('/').pop();
    if (linkPage === currentPage) {
        link.classList.add('active');
    }
});