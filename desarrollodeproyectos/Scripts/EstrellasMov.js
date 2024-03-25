document.addEventListener("DOMContentLoaded", function () {
    const stars = document.querySelectorAll(".star");
    let selectedIndex = -1; // Track the last selected star index
  
    stars.forEach(function (star, index) {
      star.addEventListener("click", function () {
        selectedIndex = index; // Update the selected index on click
        stars.forEach((star, i) => {
          star.classList.remove("clicked"); // Remove all "clicked" classes
          if (i <= selectedIndex) {
            star.classList.add("clicked"); // Add "clicked" class up to selected index
          }
        });
      });
  
      star.addEventListener("mouseover", function () {
        stars.forEach((star, i) => {
          star.classList.remove("active"); // Remove all "active" classes
          if (i <= selectedIndex) {
            star.classList.add("active"); // Add "active" class up to selected index
          }
        });
      });
  
      star.addEventListener("mouseout", function () {
        stars.forEach((star) => star.classList.remove("active")); // Remove all "active" classes on mouseout
      });
    });
  });
  
