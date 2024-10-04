function deleteSelectedCourses() {
    const selectedCourses = document.querySelectorAll('.course-checkbox:checked');
    selectedCourses.forEach(course => {
        course.closest('.course-card').remove(); // Remove the selected course card
    });
}

   // Get the modal
   const modal = document.getElementById("courseModal");

   // Get the button that opens the modal
   const btn = document.getElementById("addCourseBtn");

   // Get the <span> element that closes the modal
   const span = document.getElementsByClassName("close-btn")[0];

   // When the user clicks the button, open the modal 
   btn.onclick = function() {
       modal.style.display = "block";
   }

   // When the user clicks on <span> (x), close the modal
   span.onclick = function() {
       modal.style.display = "none";
   }

   // When the user clicks anywhere outside of the modal, close it
   window.onclick = function(event) {
       if (event.target == modal) {
           modal.style.display = "none";
       }
   }

   // Handle form submission
   document.getElementById("courseForm").onsubmit = function(e) {
       e.preventDefault(); // Prevent page reload
       const title = document.getElementById("courseTitle").value;
       const description = document.getElementById("courseDescription").value;
       const imageUrl = document.getElementById("courseImage").value;

       // Add your logic to save the course information (e.g., API call or updating the UI)

       // Close the modal after submission
       modal.style.display = "none";
       
       // Optionally reset the form
       this.reset();
   }

   document.getElementById("courseForm").onsubmit = function(e) {
    e.preventDefault(); // Prevent page reload

    // Collecting values from the form
    const courseName = document.getElementById("courseName").value;
    const courseDescription = document.getElementById("courseDescription").value;
    const courseCategory = document.getElementById("courseCategory").value;
    const courseLevel = document.getElementById("courseLevel").value;
    const coursePrice = document.getElementById("coursePrice").value;
    const courseDuration = document.getElementById("courseDuration").value;
    const courseImage = document.getElementById("courseImage").value;
    const courseLanguage = document.getElementById("courseLanguage").value;
    const courseTags = document.getElementById("courseTags").value.split(',').map(tag => tag.trim());
    const courseMaterialFilePath = document.getElementById("courseMaterialFilePath").value;
    const courseMaterialFileType = document.getElementById("courseMaterialFileType").value;
    const courseMaterialDescription = document.getElementById("courseMaterialDescription").value;

    // Add your logic to save the course information
    console.log({
        courseName,
        courseDescription,
        courseCategory,
        courseLevel,
        coursePrice,
        courseDuration,
        courseImage,
        courseLanguage,
        courseTags,
        courseMaterialFilePath,
        courseMaterialFileType,
        courseMaterialDescription
    });

    // Close the modal after submission
    modal.style.display = "none";
    
    // Optionally reset the form
    this.reset();
}
