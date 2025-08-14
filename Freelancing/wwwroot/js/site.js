// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Enhanced Freelancing Portfolio JavaScript

// Wait for DOM to be ready
document.addEventListener('DOMContentLoaded', function() {
    
    // Add smooth scrolling to all anchor links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });

    // Add loading animation to forms
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        form.addEventListener('submit', function() {
            const submitBtn = this.querySelector('button[type="submit"], input[type="submit"]');
            if (submitBtn && !submitBtn.disabled) {
                const originalText = submitBtn.innerHTML;
                submitBtn.disabled = true;
                submitBtn.innerHTML = '<i class="fas fa-spinner fa-spin me-2"></i>Processing...';
                
                // Re-enable after 5 seconds as fallback
                setTimeout(() => {
                    submitBtn.disabled = false;
                    submitBtn.innerHTML = originalText;
                }, 5000);
            }
        });
    });

    // Add hover effects to cards
    const cards = document.querySelectorAll('.card');
    cards.forEach(card => {
        card.addEventListener('mouseenter', function() {
            this.style.transform = 'translateY(-5px)';
            this.style.transition = 'all 0.3s ease';
            this.style.boxShadow = '0 10px 25px rgba(0,0,0,0.15)';
        });
        
        card.addEventListener('mouseleave', function() {
            this.style.transform = 'translateY(0)';
            this.style.boxShadow = '';
        });
    });

    // Add click animation to buttons
    const buttons = document.querySelectorAll('.btn');
    buttons.forEach(button => {
        button.addEventListener('click', function(e) {
            // Create ripple effect
            const ripple = document.createElement('span');
            const rect = this.getBoundingClientRect();
            const size = Math.max(rect.width, rect.height);
            const x = e.clientX - rect.left - size / 2;
            const y = e.clientY - rect.top - size / 2;
            
            ripple.style.cssText = `
                position: absolute;
                width: ${size}px;
                height: ${size}px;
                left: ${x}px;
                top: ${y}px;
                background: rgba(255,255,255,0.3);
                border-radius: 50%;
                transform: scale(0);
                animation: ripple 0.6s linear;
                pointer-events: none;
            `;
            
            this.style.position = 'relative';
            this.style.overflow = 'hidden';
            this.appendChild(ripple);
            
            setTimeout(() => {
                ripple.remove();
            }, 600);
        });
    });

    // Add fade-in animation to elements as they come into view
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver(function(entries) {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
                observer.unobserve(entry.target);
            }
        });
    }, observerOptions);

    // Observe elements with fade-in-up class
    document.querySelectorAll('.fade-in-up, .card, .feature-box').forEach(el => {
        el.style.opacity = '0';
        el.style.transform = 'translateY(30px)';
        el.style.transition = 'all 0.6s ease-out';
        observer.observe(el);
    });

    // Add typing effect to hero text
    const heroTitle = document.querySelector('.hero-section h1');
    if (heroTitle) {
        const text = heroTitle.textContent;
        heroTitle.textContent = '';
        let i = 0;
        
        function typeWriter() {
            if (i < text.length) {
                heroTitle.textContent += text.charAt(i);
                i++;
                setTimeout(typeWriter, 50);
            }
        }
        
        setTimeout(typeWriter, 500);
    }

    // Add counter animation for statistics
    function animateCounters() {
        const counters = document.querySelectorAll('.fs-2, .h4');
        counters.forEach(counter => {
            const text = counter.textContent;
            const match = text.match(/(\d+)/);
            if (match) {
                const target = parseInt(match[1]);
                let current = 0;
                const increment = target / 50;
                const timer = setInterval(() => {
                    current += increment;
                    if (current >= target) {
                        counter.textContent = text;
                        clearInterval(timer);
                    } else {
                        counter.textContent = text.replace(/\d+/, Math.floor(current));
                    }
                }, 30);
            }
        });
    }

    // Run counter animation when stats section comes into view
    const statsSection = document.querySelector('.row .col-6, .row .col-md-3');
    if (statsSection) {
        const statsObserver = new IntersectionObserver(function(entries) {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    animateCounters();
                    statsObserver.unobserve(entry.target);
                }
            });
        });
        statsObserver.observe(statsSection);
    }

    // Add search functionality for services
    const searchInput = document.querySelector('input[placeholder*="Search"]');
    if (searchInput) {
        searchInput.addEventListener('input', function() {
            const searchTerm = this.value.toLowerCase();
            const serviceCards = document.querySelectorAll('.service-card, .card');
            
            serviceCards.forEach(card => {
                const title = card.querySelector('.card-title');
                const description = card.querySelector('.card-text');
                
                if (title || description) {
                    const titleText = title ? title.textContent.toLowerCase() : '';
                    const descText = description ? description.textContent.toLowerCase() : '';
                    
                    if (titleText.includes(searchTerm) || descText.includes(searchTerm)) {
                        card.parentElement.style.display = '';
                        card.style.opacity = '1';
                    } else {
                        card.parentElement.style.display = 'none';
                    }
                }
            });
        });
    }

    // Add tooltip functionality
    const tooltipElements = document.querySelectorAll('[title]');
    tooltipElements.forEach(el => {
        el.addEventListener('mouseenter', function() {
            const tooltip = document.createElement('div');
            tooltip.className = 'custom-tooltip';
            tooltip.textContent = this.title;
            tooltip.style.cssText = `
                position: absolute;
                background: #333;
                color: white;
                padding: 5px 10px;
                border-radius: 4px;
                font-size: 12px;
                z-index: 1000;
                pointer-events: none;
                opacity: 0;
                transition: opacity 0.3s;
            `;
            
            document.body.appendChild(tooltip);
            
            const rect = this.getBoundingClientRect();
            tooltip.style.left = rect.left + (rect.width / 2) - (tooltip.offsetWidth / 2) + 'px';
            tooltip.style.top = rect.top - tooltip.offsetHeight - 5 + 'px';
            
            setTimeout(() => tooltip.style.opacity = '1', 10);
            
            this.addEventListener('mouseleave', function() {
                tooltip.remove();
            }, { once: true });
        });
    });

    // Add keyboard navigation
    document.addEventListener('keydown', function(e) {
        // ESC key to close modals or go back
        if (e.key === 'Escape') {
            const modal = document.querySelector('.modal.show');
            if (modal) {
                // Close modal if open
                const closeBtn = modal.querySelector('.btn-close, [data-bs-dismiss="modal"]');
                if (closeBtn) closeBtn.click();
            }
        }
        
        // Ctrl/Cmd + K to focus search
        if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
            e.preventDefault();
            const searchInput = document.querySelector('input[type="search"], input[placeholder*="Search"]');
            if (searchInput) {
                searchInput.focus();
                searchInput.select();
            }
        }
    });

    // Add progress bar for form completion
    const forms_with_progress = document.querySelectorAll('form');
    forms_with_progress.forEach(form => {
        const inputs = form.querySelectorAll('input[required], textarea[required], select[required]');
        if (inputs.length > 2) {
            const progressBar = document.createElement('div');
            progressBar.className = 'progress mb-3';
            progressBar.style.height = '4px';
            progressBar.innerHTML = '<div class="progress-bar bg-success" role="progressbar" style="width: 0%"></div>';
            
            form.insertBefore(progressBar, form.firstChild);
            
            function updateProgress() {
                const filled = Array.from(inputs).filter(input => input.value.trim() !== '').length;
                const percentage = (filled / inputs.length) * 100;
                const bar = progressBar.querySelector('.progress-bar');
                bar.style.width = percentage + '%';
                bar.setAttribute('aria-valuenow', percentage);
            }
            
            inputs.forEach(input => {
                input.addEventListener('input', updateProgress);
                input.addEventListener('change', updateProgress);
            });
            
            updateProgress();
        }
    });

    console.log('🚀 Freelancing Portfolio - Enhanced UI Loaded Successfully!');
});

// Add CSS animations
const style = document.createElement('style');
style.textContent = `
    @keyframes ripple {
        to {
            transform: scale(4);
            opacity: 0;
        }
    }
    
    .custom-tooltip {
        animation: fadeIn 0.3s ease;
    }
    
    @keyframes fadeIn {
        from { opacity: 0; transform: translateY(-5px); }
        to { opacity: 1; transform: translateY(0); }
    }
    
    .card {
        transition: all 0.3s ease;
    }
    
    .btn {
        transition: all 0.3s ease;
        overflow: hidden;
    }
    
    .navbar-nav .nav-link:hover {
        transform: translateY(-1px);
    }
    
    .form-control:focus {
        transform: scale(1.02);
    }
`;
document.head.appendChild(style);
