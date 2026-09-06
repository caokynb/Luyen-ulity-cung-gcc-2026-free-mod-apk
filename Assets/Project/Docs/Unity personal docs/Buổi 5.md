## 1. Raycasts
- Là một thành phần trong Physics 2D. Là một tia vô hình.
- Các tham số cơ bản:
	- Điểm xuất phát: Một Vector3 để làm điểm bắt đầu bắn tia ra.
	- Hướng:  Một Vector2 đã được normalized để xác định hướng bắn của tia.
	- Khoảng cách: Chiều dài của tia được bắn ra.
	- LayerMask (tùy chọn): Giúp lọc ra các lớp chỉ nhận riêng đối với tia (VD. chỉ quét layer này thay vì quét tất cả mọi thứ có Collider).
- Cách tạo một Raycast:
	``` Example
	private Vector2 rayOrigin; //Bắt đầu
    private Vector2 rayDir = Vector2.up; // Hướng
    private float dist=5; //Khoảng cách
    private LayerMask targetLayer; //LayerMask
    void Update()
    {
        rayOrigin = transform.position; //gán điểm bắt đầu với điểm hiện tại của GameObject
        CheckRay(); //Gọi hàm vẽ
    }

    void CheckRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDir, dist, targetLayer); //Vẽ một ray
    }
	```
- Vì Raycast khi vẽ bình thường thì nó sẽ vô hình -> không thấy được khi run game. Vậy nên cũng nên dùng cả `Debug.DrawRay`.
	- Cũng gồm 3 thành phần:
		- Bắt đầu.
		- Hướng / Độ dài.
		- Color / Màu.
		- Duration (OVERLOAD).
``` Example
void CheckRay()
{
	RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDir, dist, targetLayer); //Vẽ một ray
    Debug.DrawRay(rayOrigin,rayDir*5,Color.red); // Vẽ một ray Debug có thể thấy được
    }
```
- Ray cũng có collider riêng của nó:
``` Example
	RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDir, dist); //Vẽ một ray
    Debug.DrawRay(rayOrigin,rayDir*5,Color.red); // Vẽ một ray Debug có thể thấy được
    if (hit.collider != null)
    {
	    Debug.Log("Đã đụng gì đó!");
    }
```
- Có các loại biến thể của Raycast là Overlap (Không hẳn là vẽ ra nhưng là check collider theo hình được gọi):
	- `OverlapCircle`: Thay vì vẽ tia thì vẽ một hình tròn.
	- `OverlapBox`: Vẽ hình hộp.
	- `OverlapPoint`: Vẽ một chấm ở một tọa độ.
- Đương nhiên là cũng có thể cast được các hình khối:
	- `CircleCast`:
	- `BoxCast`:
- Cast và Overlap khác nhau ở chỗ là Overlap chỉ kiểm tra ở vùng tĩnh còn Cast sẽ chạy theo hướng đã được truyền vào với khoảng cách truyền vào và kiểm tra xung quanh phạm vi đó.
## 2. Layer Mask 
- Là bộ lọc dành cho phần trên, giúp các hàm như Raycast hay Overlap chỉ tương tác với các layer được chỉ định thay vì quét tất cả mọi thứ, giúp tối ưu hiệu năng và tránh va chạm nhầm. 
- Thay vì chỉ định bằng Inspector, có thể chuyển đổi tên layer thành LayerMask thông qua các cách sau: 
	- `LayerMask.GetMask("TênLayer")`: Lấy trực tiếp LayerMask từ tên (có thể truyền nhiều tên layer cách nhau bởi dấu phẩy). 
	- `LayerMask.NameToLayer("TênLayer")`: Lấy chỉ số (index) của layer thông qua tên rồi dịch bit để tạo ra LayerMask. ``` 
- Cách dùng:
``` Example
[SerializeField] private LayerMask targetLayer; //chọn layer trong inspector luôn  void Start()
{ 
	targetLayer = LayerMask.GetMask("Ground"); // Hoặc có thể gọi hẳn tên ra
	//nametolayer thì... em chịu
}
```