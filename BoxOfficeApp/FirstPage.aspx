<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstPage.aspx.cs" Inherits="BoxOfficeApp.FirstPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Box Office App</title>
        <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            // Handler for movie selection
            $('#dropDownMovies').change(function () {
                var selectedMovieId = $(this).val();

                // Check if the selected movie is valid
                if (selectedMovieId !== "0") {
                    // Fetch movie details including the image URL from the server
                    $.ajax({
                        type: "POST",
                        url: "FirstPageMovieImage.ashx",
                        data: { movieId: selectedMovieId },
                        dataType: "json",
                        success: function (response) {
                            // Check if the response has the ImageURL property
                            if (response && response.ImageURL) {
                                // Update the image src based on the response
                                $('#imgMovie').attr('src', response.ImageURL);
                            } else {
                                // Handle the case when the response doesn't have ImageURL
                                console.error('Invalid response format. ImageURL not found.');
                            }
                        },
                        error: function () {
                            alert("Error fetching movie details.");
                        }
                    });
                }
            });
        });
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to Box Office App</h1>
            <div>
                <label for="dropDownMovies">Select Movie:</label>
                <asp:DropDownList ID="dropDownMovies" runat="server">
                </asp:DropDownList>
                 <img id="imgMovie" src="" alt="Movie Image" style="max-width: 300px; max-height: 300px;" />
            </div>
            <div>
                <label for="txtDate">Select Date:</label>
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div>
                <label for="txtQuantity">Quantity:</label>
                <asp:TextBox ID="txtQuantity" runat="server" Text="1"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="ticketResponse" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Button ID="btnBuyTickets" runat="server" Text="Buy Tickets" OnClick="btnBuyTickets_Click" />
            </div>
        </div>
    </form>
</body>
</html>
