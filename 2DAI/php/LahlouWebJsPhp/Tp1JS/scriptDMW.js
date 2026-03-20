document.addEventListener('DOMContentLoaded', function() {
    const registerBtn = document.getElementById('registerBtn');
    if (registerBtn) {
        registerBtn.addEventListener('click', function(e) {
            e.preventDefault(); // Prevent default form submission
            inscription();
        });
    }
    

    const loginBtn = document.getElementById('loginBtn');
    if (loginBtn) {
        loginBtn.addEventListener('click', function(e) {
            e.preventDefault();
            connexion();
        });
    }
    
    if (window.location.pathname.includes('profile.html')) {
        window.addEventListener('load', function() {
            setTimeout(afficherProfile, 100);
        });
    }
});

// Expose functions globally so they can be used in onclick attributes if needed
window.emailValide = emailValide;
window.inscription = inscription;
window.connexion = connexion;
window.afficherProfile = afficherProfile;