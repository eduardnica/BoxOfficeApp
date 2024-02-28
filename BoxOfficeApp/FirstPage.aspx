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

                if (selectedMovieId === "0") {
                    $('#imgMovie').show();
                    $.ajax({
                        type: "POST",
                        url: "Handlers/StaticImageHandler.ashx",
                        dataType: "json",
                        success: function (response) {
                            if (response && response.StaticImageURL) {
                                $('#imgMovie').attr('src', response.StaticImageURL);
                            } else {
                                console.error('Invalid response format. StaticImageURL not found.');
                            }
                        },
                        error: function () {
                            alert("Error fetching static image details.");
                        }
                    });
                } else {
                    //if (selectedMovieId !== "0") {
                    $('#imgMovie').show();
                    $.ajax({
                        type: "POST",
                        url: "Handlers/FirstPageMovieImage.ashx",
                        data: { movieId: selectedMovieId },
                        dataType: "json",
                        success: function (response) {
                            if (response && response.ImageURL) {
                                $('#imgMovie').attr('src', response.ImageURL);
                            } else {
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
            </div>

            <div>
              <img id="imgMovie" src="" alt="Movie Image" style="max-width: 300px; max-height: 300px; display: none;" />
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






    <style>
    body {
        font-family: 'Arial', sans-serif;
        background-color: #f8f8f8;
        margin: 0;
        padding: 0;
        display: flex;
        align-items: center;
        justify-content: center;
        height: 100vh;
    }

    form {
        background-color: #fff;
        border-radius: 8px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        padding: 20px;
        width: 300px;
    }

    h1 {
        color: #333;
        text-align: center;

    }

    label {
        display: block;
        margin-bottom: 5px;
    }

    div {
        margin-bottom: 15px;
    }

    #imgMovie {
        max-width: 100%;
        max-height: 300px;
        display: none;
        margin-top: 10px; /* Add some space between the image and other elements */
        margin-left: auto;
        margin-right: auto;
        display: block; /* Make it a block-level element to center horizontally */
    }

    input[type="date"],
    input[type="text"] {
        width: calc(100% - 6px);
        padding: 8px;
        margin-bottom: 10px;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
    }

    #btnBuyTickets {
        background-color: #4caf50;
        color: #fff;
        padding: 10px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        font-size: 16px;
        width: 100%;
    }

    #btnBuyTickets:hover {
        background-color: #45a049;
    }

    #ticketResponse {
        color: #ff0000;
        font-size: 14px;
        margin-top: 10px;
    }
</style>