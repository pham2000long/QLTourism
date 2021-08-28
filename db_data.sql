USE [tourism]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([id], [username], [password], [name], [email], [phone], [gender], [city], [country], [avatar], [birthday], [address]) VALUES (1, N'longpham', N'123456', N'Phạm Julia', N'pham2000long@gmail.com', N'0974469808', 1, N'Denver 2', N'Viet Nam', N'27082021_043510_PM_emyeu.jpg', CAST(N'1982-11-11' AS Date), N'6106-6134 Washington St')
INSERT [dbo].[Customers] ([id], [username], [password], [name], [email], [phone], [gender], [city], [country], [avatar], [birthday], [address]) VALUES (2, N'longpham2', N'123456', N'Phạm Julia', N'pham2000long@gmail.com', N'0974469808', NULL, N'Denver', N'Viet Nam', N'27082021_042800_PM_emyeu.jpg', CAST(N'1982-11-11' AS Date), N'6106-6134 Washington St')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([id], [bookingDate], [bookingNo], [customerId], [country], [city], [address], [customerNote]) VALUES (1, CAST(N'2021-08-28T19:23:36.643' AS DateTime), N'255036631', 1, N'Viet Nam', N'Denver 2', N'6106-6134 Washington St', N'')
INSERT [dbo].[Bookings] ([id], [bookingDate], [bookingNo], [customerId], [country], [city], [address], [customerNote]) VALUES (2, CAST(N'2021-08-28T19:48:40.177' AS DateTime), N'844597921', 1, N'Viet Nam', N'Denver 2', N'6106-6134 Washington St', N'hellloooooooo')
INSERT [dbo].[Bookings] ([id], [bookingDate], [bookingNo], [customerId], [country], [city], [address], [customerNote]) VALUES (3, CAST(N'2021-08-28T21:26:46.333' AS DateTime), N'752497541', 1, N'Viet Nam', N'Denver 2', N'6106-6134 Washington St', N'')
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([id], [name], [parentId]) VALUES (1, N'Tour Trong Nước', 0)
INSERT [dbo].[Categories] ([id], [name], [parentId]) VALUES (2, N'Tour Nước Ngoài', 0)
INSERT [dbo].[Categories] ([id], [name], [parentId]) VALUES (3, N' Miền Bắc', 1)
INSERT [dbo].[Categories] ([id], [name], [parentId]) VALUES (4, N'Miền Trung', 1)
INSERT [dbo].[Categories] ([id], [name], [parentId]) VALUES (5, N'Miền Nam', 1)
INSERT [dbo].[Categories] ([id], [name], [parentId]) VALUES (6, N'Hà Nội', 3)
INSERT [dbo].[Categories] ([id], [name], [parentId]) VALUES (7, N'Hải Phòng', 3)
INSERT [dbo].[Categories] ([id], [name], [parentId]) VALUES (8, N'Châu Á', 2)
INSERT [dbo].[Categories] ([id], [name], [parentId]) VALUES (9, N'Châu Âu', 2)
INSERT [dbo].[Categories] ([id], [name], [parentId]) VALUES (10, N'Châu Mĩ', 2)
INSERT [dbo].[Categories] ([id], [name], [parentId]) VALUES (11, N'Đài Loan', 8)
INSERT [dbo].[Categories] ([id], [name], [parentId]) VALUES (12, N'Hàn Quốc', 8)
INSERT [dbo].[Categories] ([id], [name], [parentId]) VALUES (13, N'Anh', 9)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Packages] ON 

INSERT [dbo].[Packages] ([id], [pkgName], [pkgStartDate], [pkgTimePeriod], [pkgStartPlace], [pkgEndPlace], [pkgDesc], [pkgRules], [pkgTransporter], [pkgBasePrice], [pkgCondition], [pkgSlot], [active], [categoryId], [thumbail]) VALUES (1, N'COMBO 3 NGÀY 2 ĐÊM HÀ NỘI | KHÁCH SẠN 4* 5* + TOUR ĐI BỘ NỬA NGÀY', CAST(N'2021-08-28' AS Date), N'3 ngày', N'Hà Nội', N'Hà Nội', N'<p style="text-align: center;"><span lang="EN-GB"><strong>Tham quan Hà Nội: Bảo tàng Lịch Sử quốc gia - Nhà Hát Lớn - Di tích Bắc Bộ Phủ</strong></span></p>
<p style="text-align: center;"><span lang="EN-GB">Liên hệ cùng chúng tôi qua Tổng đài: <a href="tel:19004518">19004518</a> hoặc Hotline: <a href="tell: 0904886561">0904 886 561</a>  - Email: <a href="mailto:sm-operation@hanoitourist-travel.com%20">sm-operation@hanoitourist-travel.com</a></span></p>
<p> </p>
<p><strong><span lang="EN-GB">- Bảo tàng Lịch Sử quốc gia Việt Nam</span></strong><span lang="EN-GB">, nơi lưu giữ, trưng bày và giới thiệu lịch sử Việt Nam với kiến trúc đặc sắc cùng các hiện vật vô cùng đồ sộ, quý giá, trong đó có nhiều hiện vật là Bảo vật quốc gia như: Trống Đồng Đông Sơn - biểu tượng của văn hoá Việt Nam, Kim Sách - một loại thư tịch cổ đặc biệt được làm bằng vàng và rất có giá trị về mặt lịch sử, Kim Ấn - hiện vật biểu tượng cho quyền uy tối cao của các vua triều Nguyễn </span></p>
<p><span lang="EN-GB"><strong>- Nhà Hát Lớn Hà Nội</strong>,</span> <span lang="EN-GB">một công trình kiến trúc có một không hai với những giá trị kiệt xuất về lịch sử, văn hoá, kiến trúc và mỹ thuật, là bằng chứng lịch sử của sự phát triển văn hoá và xã hội của Hà Nội và Việt Nam thời kỳ Pháp thuộc, là một di tích của một giai đoạn phát triển kiến trúc ở Việt Nam, một trung tâm văn hoá tiêu biểu không chỉ của Hà Nội, của Việt Nam mà còn của cả khu vực Đông Nam Á</span></p>
<p><span lang="EN-GB"><strong>- Di tích lịch sử cách mạng Bắc Bộ Phủ</strong>, </span><span lang="EN-GB">nơi diễn ra cuộc đấu tranh cướp chính quyền của nhân dân Thủ đô Hà Nội năm 1945 đã đi vào lịch sử như một minh chứng cho sự vùng lên quật khởi để giành và bảo vệ quyền sống trong độc lập, tự do và hòa bình của dân tộc Việt Nam, một </span><span lang="EN-GB">công trình có giá trị đặc biệt về kiến trúc của Đông Dương mang phong cách Châu Âu, là nơi ở và làm việc của Chủ tịch Hồ Chí Minh trong những ngày đầu tiên của nước Việt Nam Dân chủ Cộng hòa.</span></p>
<h3 style="font-weight: 500;"><strong>ĐIỀU KIỆN - QUY ĐỊNH</strong></h3>
<p>Điều kiện:</p>
<p><strong>- Combo áp dụng với nhóm từ 02 khách trở lên.</strong></p>
<p><strong>- Giá trị đến 31/12/2020.</strong></p>
<p><strong>* Giá bao gồm:</strong></p>
<p>- Xe đón tiễn sân bay Nội Bài,</p>
<p>- 2 đêm ngủ tại khách sạn 4-5 sao tại Hà Nội (2 khách/phòng, bao gồm ăn sáng),</p>
<p>- vé vào cửa các điểm tham quan theo chương trình thăm quan Hà Nội nửa ngày, hướng dẫn viên theo chương trình thăm quan,</p>
<p>- 01 bữa ăn trưa hoặc ăn tối tại nhà hàng trong khuôn viên Bắc Bộ Phủ. </p>
<p><strong>* Giá không bao gồm:</strong></p>
<p>- Ngủ phòng đơn</p>
<p>- Đồ uống</p>
<p>- Chi phí ngoài chương trình.</p>
<p>- Các chi phí cá nhân.</p>
<p>- Tiền bồi dưỡng cho HDV và Lái xe.</p>
<p>- Phụ phí với người Nước ngoài - Việt Kiều (nếu có)</p>
<p><strong>*Chính sách thanh toán:</strong></p>
<p>- Thanh toán 50% giá trị tour sau khi đặt tour</p>
<p>- Thanh toán 50% số tiền còn lại 15 ngày trước ngày khởi hành.</p>
<p> </p>
<p><strong>* Chính sách hoàn huỷ:</strong></p>
<p>-         Nếu quý khách hủy tour sau khi đăng ký và trước 15 ngày khởi hành: phí hủy 50% giá combo.</p>
<p>-         Nếu quý khách hủy tour trước 7 ngày khởi hành: phí hủy 70%  giá combo</p>
<p>-         Nếu quý khách hủy tour trong vòng 02 ngày trước ngày khởi hành: phí hủy 100% giá combo</p>
<p> </p>
<p><strong>* Lưu ý:</strong></p>
<p>-         Thứ tự các điểm thăm quan có thể thay đổi để phù hợp với chương trình thực tế của đoàn song vẫn đảm bảo đầy đủ các điểm thăm quan.</p>
<p> </p>
<p>- Trong trường hợp khách hàng được hoàn tiền theo hình thức chuyển khoản, khách hàng sẽ chịu phí chuyển khoản (nếu có)</p>', N'Không hoàn tiền khi đã đặt', N'Ô tô', 1000000, N'Còn chỗ', 100, 1, 6, N'28082021_124721_AM_161185.jpg')
INSERT [dbo].[Packages] ([id], [pkgName], [pkgStartDate], [pkgTimePeriod], [pkgStartPlace], [pkgEndPlace], [pkgDesc], [pkgRules], [pkgTransporter], [pkgBasePrice], [pkgCondition], [pkgSlot], [active], [categoryId], [thumbail]) VALUES (4, N'TOUR ĐÊM HOÀNG THÀNH THĂNG LONG', CAST(N'2021-08-30' AS Date), N'1 ngày 0 đêm', N'Hà Nội', N'Hà Nội', N'<p style="font-weight: 400;"><strong>TOUR ĐÊM GIẢI MÃ HOÀNG THÀNH THĂNG LONG</strong></p>
<p style="font-weight: 400;"><strong>Thời lượng: 90 phút</strong></p>
<p style="font-weight: 400;"><strong>Khởi hành lúc 18h00, 18h30, 19h00 các tối thứ 7 và chủ Nhật hàng tuần</strong></p>
<p style="font-weight: 400;"> </p>
<p style="font-weight: 400;">9 LÝ DO BẠN KHÔNG NÊN BỎ LỠ TOUR ĐÊM</p>
<ol>
<li style="font-weight: 400;">Trải nghiệm khu Di sản văn hóa thế giới Hoàng thành Thăng Long được UNESCO ghi danh, trong không gian khác biệt với <strong>ánh sáng lung linh đậm chất hoàng cung</strong>lần đầu được giới thiệu</li>
<li style="font-weight: 400;">Chụp hình với những <strong>“chú lính gác” và “cung nữ”</strong>trong trang phục cổ xưa</li>
<li style="font-weight: 400;">Thưởng thức màn trình diễn <strong>múa cổ “Cung đình Thăng Long”</strong>với những vũ công xinh đẹp</li>
<li style="font-weight: 400;">Tham dự Lễ <strong>dâng văn và dâng hương tưởng nhớ 52 vị tiên đế</strong>tại điện Kính Thiên -  Nơi được coi là huyệt đạo của kinh thành Thăng Long xưa</li>
<li style="font-weight: 400;">Tham quan khu khảo cổ với những hiện vật hé lộ những <strong>câu chuyện bước ra từ nghìn năm lịch sử</strong></li>
<li style="font-weight: 400;">Có cơ hội tự tay lấy cho mình <strong>dòng nước của giếng Vua</strong>biểu tượng cho sự linh thiêng và phúc lành</li>
<li style="font-weight: 400;">Tham gia trò chơi “Giải mã Hoàng thành Thăng Long” bằng <strong>thẻ giải mã với màn trình diễn laze</strong>bật mí ấn tượng và những phần quà hấp dẫn đầy ý nghĩa</li>
<li style="font-weight: 400;">Mua sắm những sản phẩm lưu niệm đặc trưng thể hiện cho sự may mắn và sung túc</li>
<li style="font-weight: 400;">Trong không gian rộng lớn của Hoàng thành, du khách vừa <strong>thoải mái khám phá</strong>vừa đảm bảo <strong>an toàn chống dịch </strong>Covid-19 với nguyên tắc “5K”</li>
</ol>', N'Không hoàn tiền khi đã đặt', N'Ô tô', 150, N'Còn chỗ', 60, 1, 6, N'28082021_125001_AM_173011.jpg')
SET IDENTITY_INSERT [dbo].[Packages] OFF
GO
SET IDENTITY_INSERT [dbo].[BookingDetails] ON 

INSERT [dbo].[BookingDetails] ([id], [Price], [bookingId], [packageId], [bookingInfor]) VALUES (1, 870000, 1, 1, N'2 người - 3 suất')
INSERT [dbo].[BookingDetails] ([id], [Price], [bookingId], [packageId], [bookingInfor]) VALUES (2, 580000, 2, 1, N'2 người - 2 suất')
INSERT [dbo].[BookingDetails] ([id], [Price], [bookingId], [packageId], [bookingInfor]) VALUES (3, 4500000, 2, 4, N'2 người - 3 suất')
INSERT [dbo].[BookingDetails] ([id], [Price], [bookingId], [packageId], [bookingInfor]) VALUES (4, 1450000, 3, 1, N'2 người - 5 suất')
SET IDENTITY_INSERT [dbo].[BookingDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Prices] ON 

INSERT [dbo].[Prices] ([id], [title], [price], [packageId]) VALUES (1, N'2 người', 1500000, 4)
INSERT [dbo].[Prices] ([id], [title], [price], [packageId]) VALUES (2, N'2 người', 290000, 1)
SET IDENTITY_INSERT [dbo].[Prices] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([id], [name]) VALUES (1, N'admin')
INSERT [dbo].[Roles] ([id], [name]) VALUES (2, N'edit')
INSERT [dbo].[Roles] ([id], [name]) VALUES (3, N'sale')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [username], [password], [name], [email], [phone], [gender], [avatar], [birthday], [address], [roleId]) VALUES (3, N'longpham', N'123456', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([id], [username], [password], [name], [email], [phone], [gender], [avatar], [birthday], [address], [roleId]) VALUES (5, N'longbhtl', N'123456', N'Phạm Julia', N'pham2000long@gmail.com', N'0974469808', 1, NULL, CAST(N'1982-11-11' AS Date), N'6106-6134 Washington St', 2)
INSERT [dbo].[Users] ([id], [username], [password], [name], [email], [phone], [gender], [avatar], [birthday], [address], [roleId]) VALUES (6, N'haui', N'123456', NULL, NULL, NULL, 1, NULL, NULL, NULL, 1)
INSERT [dbo].[Users] ([id], [username], [password], [name], [email], [phone], [gender], [avatar], [birthday], [address], [roleId]) VALUES (7, N'2018600640', N'123456', NULL, NULL, NULL, 1, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Sliders] ON 

INSERT [dbo].[Sliders] ([id], [name], [imagePath], [urlPath]) VALUES (1, N'Du lịch Phương Bắc', N'28082021_121549_AM_172661.jpg', NULL)
SET IDENTITY_INSERT [dbo].[Sliders] OFF
GO
