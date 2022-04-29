<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NuevoLogin2.ascx.cs" Inherits="ListasSarlaft.UserControls.Sitio.NuevoLogin2" %>
<!-- section -->
<section class="register">
	<div class="register-full">
		<div class="register-left">
			<div class="register" >
                <asp:Image ID="imgPub" runat="server" ImageUrl="../../Imagenes/Aplicacion/SherlockBanner-1.jpg" />
			</div>
		</div>
		<div class="register-right">
			<div class="register-in">
				<h2><span class="fa fa-pencil"></span> register here</h2>
				<div class="register-form">
					<form action="#" method="post">
						<div class="fields-grid">
							<div class="styled-input agile-styled-input-top">
								<input type="text" name="First name" required> 
								<label>Enter Full Name</label>
								<span></span>
							</div>
							<div class="styled-input">
								<input type="email" name="Email" required>
								<label>Email</label>
								<span></span>
							</div>
							<div class="styled-input">
								<input type="tel" name="Phone" required>
								<label>Phone Number</label>
								<span></span>
							</div>
							<div class="styled-input">
								<input type="password" name="password" required>
								<label>Password</label>
								<span></span>
							</div>
							<div class="styled-input agile-styled-input-top">
								<select id="category2" required="">
									<option value="">Course Type*</option>
									<option value="">Diploma</option>
									<option value="">Full time</option>
									<option value="">Part time</option>
									<option value="">Higher degree</option>
									<option value="">Graduate</option>
									<option value="">Pg</option>
									<option value="">Degree</option>
								</select>
								<span></span>
							</div>
							<div class="clear"> </div>
							 <label class="checkbox"><input type="checkbox" name="checkbox" checked><i></i>I agree to the <a href="#">Terms and Conditions</a></label>
						</div>
						<input type="submit" value="Register">
					</form>
				</div>
			</div>
			<div class="clear"> </div>
		</div>
	<div class="clear"> </div>
	</div>
	<!-- copyright -->
	<p class="agile-copyright">© 2018 Course Register Form. All Rights Reserved | Design by <a href="https://w3layouts.com/" target="_blank">W3layouts</a></p>
	<!-- //copyright -->
</section>
<!-- //section -->