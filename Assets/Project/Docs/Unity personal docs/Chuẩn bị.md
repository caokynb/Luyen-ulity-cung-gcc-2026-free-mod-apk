
## 1. Ôn tập & Từ khóa kỹ thuật liên quan 
* Trigger 2D, Raycast 2D 
* LayerMask
* Prefab 
* `Instantiate` 
--- 
## 2. Tiến độ Gameplay hiện tại 
* ***Nhân vật di chuyển:* (Done)** 
* ***Quái di chuyển:*** Di chuyển qua lại trái - phải (có chạm vào người chơi). 
* **Nhân vật bắn đạn (`Bullet`):** 
* `Bullet` chạm quái: Gây dame (in `Log` ra Console), đạn biến mất (`Destroy`). 
* Quái dính đạn: Mất máu; khi hết máu $\rightarrow$ quái biến mất (`Destroy`). 
--- 
## 3. Lý thuyết bài mới cần chuẩn bị 
* ***Sự kiện (Event) trong C# & Unity:*** 
* `Action` **(tìm hiểu sơ qua)** 
* `Delegate` **(tìm hiểu sơ qua)** 
* `UnityEvent` **(tập trung chính)** 
* Cách đăng ký sự kiện đối với từng cách. 
* Cách gọi (phát) Event thông qua `Invoke()`. 
* ***Coroutine trong Unity:*** 
* Khái niệm luồng Coroutine. 
* Cách sử dụng: `yield return null`, `yield return new WaitForSeconds(...)`. 
* Cách bắt đầu và dừng: `StartCoroutine`, `StopCoroutine`. 
--- 
## 4. Yêu cầu bài tập mới (Game Task) Áp dụng ***Event*** và ***Coroutine*** vào Gameplay: 
* ***Khi Player bắn:*** 
* Bắn ra một Event thông báo. 
* UI (hoặc Log) hiển thị số lượng đạn giảm đi 1. 
* Người chơi bị đẩy lùi một đoạn (Knockback / giật khi bắn). 
* ***Nhiệm vụ tùy chọn (Optional):*** 
* Hoàn thiện hiệu ứng hiển thị: Sau 1 khoảng thời gian thì ẩn đi (sử dụng Coroutine để đếm thời gian trễ).