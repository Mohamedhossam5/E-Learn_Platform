const container_top = document.querySelector('.top-rated');
const prevArrow_top = document.querySelector('#arrows .fa-chevron-left.top');
const nextArrow_top = document.querySelector('#arrows .fa-chevron-right.top');

prevArrow_top.addEventListener('click', () => {
  container_top.scrollBy({ left: -container_top.clientWidth, behavior: 'smooth' });

});

nextArrow_top.addEventListener('click', () => {
  container_top.scrollBy({ left: container_top.clientWidth, behavior: 'smooth' });
});


const container_all = document.querySelector('.all');
const prevArrow_all = document.querySelector('#arrows .fa-chevron-left.allc');
const nextArrow_all = document.querySelector('#arrows .fa-chevron-right.allc');
prevArrow_all.addEventListener('click', () => {
  container_all.scrollBy({ left: -container_all.clientWidth, behavior: 'smooth' });

});

nextArrow_all.addEventListener('click', () => {
  container_all.scrollBy({ left: container_all.clientWidth, behavior: 'smooth' });
});


const all_courses_container = document.querySelector(".view-all-courses")
all_courses_container.style.display="None";

// Select elements
const homeButton = document.querySelector('.home');
const coursesButton = document.querySelector('.courses-button');
const viewAllCourses = document.querySelector('.view-all-courses');
const allCourses = document.querySelector('.all');
const topRated = document.querySelector('.top-rated');
const running = document.querySelector('.running');

// Function to hide all sections
function hideAllSections() {
    allCourses.style.display = 'none';
    topRated.style.display = 'none';
    running.style.display = 'none';
}

function showAllSections() {
    allCourses.style.display = 'flex';
    topRated.style.display = 'flex';
    running.style.display = 'flex';
}

// Event listener for Home button
homeButton.addEventListener('click', () => {
    viewAllCourses.style.display = 'none'; // Hide courses
    showAllSections();
});

// Event listener for Courses button
coursesButton.addEventListener('click', () => {
    hideAllSections();
    viewAllCourses.style.display = 'flex'; // Show courses
});
