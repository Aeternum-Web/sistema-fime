// JavaScript vanilla para SistemaFIME
(function() {
    'use strict';

    // Inicialización cuando el DOM esté listo
    document.addEventListener('DOMContentLoaded', function() {
        initializeNavigation();
        initializeBlazor();
    });

    // Navegación móvil
    function initializeNavigation() {
        const navToggler = document.querySelector('.navbar-toggler');
        const sidebar = document.querySelector('.sidebar');
        const navMenu = document.querySelector('.nav-scrollable');

        if (navToggler && navMenu) {
            navToggler.addEventListener('click', function() {
                navMenu.classList.toggle('show');
                sidebar.classList.toggle('show');
            });

            // Cerrar menú al hacer clic en un enlace (móvil)
            const navLinks = document.querySelectorAll('.nav-link');
            navLinks.forEach(function(link) {
                link.addEventListener('click', function() {
                    if (window.innerWidth < 768) {
                        navMenu.classList.remove('show');
                        sidebar.classList.remove('show');
                    }
                });
            });
        }

        // Cerrar menú al redimensionar ventana
        window.addEventListener('resize', function() {
            if (window.innerWidth >= 768) {
                navMenu.classList.remove('show');
                sidebar.classList.remove('show');
            }
        });
    }

    // Funciones para Blazor
    function initializeBlazor() {
        // Funciones que pueden ser llamadas desde Blazor
        window.blazorFunctions = {
            showAlert: function(message, type = 'info') {
                showNotification(message, type);
            },
            
            scrollToTop: function() {
                window.scrollTo({ top: 0, behavior: 'smooth' });
            },
            
            focusElement: function(elementId) {
                const element = document.getElementById(elementId);
                if (element) {
                    element.focus();
                }
            }
        };
    }

    // Sistema de notificaciones simple
    function showNotification(message, type = 'info') {
        const notification = document.createElement('div');
        notification.className = `alert alert-${type} notification`;
        notification.textContent = message;
        notification.style.cssText = `
            position: fixed;
            top: 20px;
            right: 20px;
            z-index: 9999;
            min-width: 300px;
            animation: slideIn 0.3s ease-out;
        `;

        document.body.appendChild(notification);

        // Auto-remover después de 5 segundos
        setTimeout(function() {
            notification.style.animation = 'slideOut 0.3s ease-in';
            setTimeout(function() {
                if (notification.parentNode) {
                    notification.parentNode.removeChild(notification);
                }
            }, 300);
        }, 5000);
    }

    // Animaciones CSS
    const style = document.createElement('style');
    style.textContent = `
        @keyframes slideIn {
            from {
                transform: translateX(100%);
                opacity: 0;
            }
            to {
                transform: translateX(0);
                opacity: 1;
            }
        }
        
        @keyframes slideOut {
            from {
                transform: translateX(0);
                opacity: 1;
            }
            to {
                transform: translateX(100%);
                opacity: 0;
            }
        }
        
        .notification {
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }
    `;
    document.head.appendChild(style);

})();