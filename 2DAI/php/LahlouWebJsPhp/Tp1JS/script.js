
// Import all function files
const functions = [
    'functions/emailValide.js',
    'functions/inscription.js', 
    'functions/connexion.js',
    'functions/afficherProfile.js'
];

functions.forEach(file => {
    const script = document.createElement('script');
    script.src = file;
    document.head.appendChild(script);
});

// Wait for DOM to be loaded and attach event listeners
document.addEventListener('DOMContentLoaded', () => {
    // Register button event
    const registerBtn = document.getElementById('registerBtn');
    registerBtn && registerBtn.addEventListener('click', e => {
        e.preventDefault();
        inscription();
    });

    // Login button event
    const loginBtn = document.getElementById('loginBtn');
    loginBtn && loginBtn.addEventListener('click', e => {
        e.preventDefault();
        connexion();
    });

    // Profile page load
    window.location.pathname.includes('profile.html') && window.addEventListener('load', () => {
        setTimeout(afficherProfile, 100);
    });
});