<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resena.aspx.cs" Inherits="desarrollodeproyectos.forms.Resena" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<title>Estrellas</title>
<link href="~/Scripts/css/bootstrap.css" rel="stylesheet" />
<link href="~/Scripts/css/estrella.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <section class="reseñas centrado">
            <h2>Reseñas</h2>
            <div class="calificación">
                <span class="estrella llena"></span>
                <span class="estrella llena"></span>
                <span class="estrella llena"></span>
                <span class="estrella llena"></span>
                <span class="estrella"></span>
            </div>

            <asp:Panel ID="Panel1" runat="server">
                <ul class="estrellas">
                    <li><a href="#" class="star">&#9733;</a></li>
                    <li><a href="#" class="star">&#9733;</a></li>
                    <li><a href="#" class="star">&#9733;</a></li>
                    <li><a href="#" class="star">&#9733;</a></li>
                    <li><a href="#" class="star">&#9733;</a></li>
                </ul>
                </asp:Panel>
                <asp:TextBox ID="comentario" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
                
                <asp:Button ID="Enviar" runat="server" Text="Enviar" />
            
        </section>
    </form>
<script>document.addEventListener("DOMContentLoaded", function () {
        const stars = document.querySelectorAll(".star");
        let selectedIndex = -1; // Track the last selected star index

        stars.forEach(function (star, index) {
            star.addEventListener("click", function () {
                selectedIndex = index; // Update the selected index on click
                updateStars(); // Update the stars based on the selected index
            });

            star.addEventListener("mouseover", function () {
                updateStars(index); // Temporarily update the stars on mouseover
            });

            star.addEventListener("mouseout", function () {
                updateStars(); // Revert to the selected state on mouseout
            });
        });

        function updateStars(tempIndex = selectedIndex) {
            stars.forEach((star, i) => {
                star.classList.remove("clicked", "active"); // Remove all "clicked" and "active" classes
                if (i <= tempIndex) {
                    star.classList.add("active"); // Add "active" class up to the current index
                }
                if (i <= selectedIndex) {
                    star.classList.add("clicked"); // Add "clicked" class up to the selected index
                }
            });
        }
});
//
</script>
</body>
</html>