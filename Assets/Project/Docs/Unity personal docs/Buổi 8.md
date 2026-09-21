## 1. Blend Tree
- Trong mô hình FSM của Animator, ví dụ như animation nhảy thì sẽ có 3 trạng thái là {Bắt đầu nhảy, Bắt đầu rơi, rơi} thì thay vì cho tất cả 3 state vào trong và nối các transition, điều đó sẽ gây rắc rối và khó debug sau này thì hãy bỏ hết 3 state đó vào một Blend Tree.
- Blend Tree là một "Tổng hợp" các trạng thái nằm trong nó và sẽ blend các trạng thái trong nó theo parameter.
- VD: Nhảy sẽ có parameter là VelocityY, khi nhảy thì velocity sẽ tăng và ngược lại. Sẽ có các threshold của parameter trong đó và slider điều chỉnh. Sẽ chỉnh từng cái như sau:
	- BeginJump: 1
	- BeginFall: 0
	- Fall: -1
- Khi nhảy thì velocity sẽ tăng lên 1, đồng nghĩa chạy animation đầu tiên, sau đó sẽ đến peak của bước nhảy, thì Velocity sẽ = 0, chơi animation BeginFall. Cuối cùng là rơi thì velocity sẽ âm, chơi animation Fall
## 2. Finite State Machine
- Sẽ có nhiều loại FSM. Buổi này tập trung vào State Pattern.
- Reference: [The State Pattern](https://onewheelstudio.com/blog/2020/6/16/the-state-pattern)
- Một state pattern cơ bản sẽ có cấu trúc gồm:
	1. State Interface: Chứa các hàm mà mọi trạng thái phải có.
	2. States: kế thừa Interface. Mỗi state sẽ chia thành các class riêng biệt và mỗi class chứa các logic vào bên trong các hàm của vòng đời, sẽ có các điều kiện để chuyến sang trạng thái tiếp theo.
	3. State Machine: Là một class trung tâm gắn lên `GameObject` cần các trạng thái đó. Chỉ phục vụ mục đích thay đổi các trạng thái hoặc update trạng thái hiện tại.
- Đầu tiên sẽ phải khởi tạo một class interface:
``` C#
public interface IState
{
    public void Enter();
    public void Tick();
    public void FixedTick();
    public void Exit();
}
```
- Class interface này sẽ chứa tất cả các hàm mà mọi trạng thái phải có.
	- `Enter()`: Giống hàm Awake.
	- `Tick()`: Giống Update.
	- `FixedTick()`: Giống FixedUpdate.
	- `Exit()`: Thoái trạng thái hiện tại.
- Tiếp theo ta tạo một bộ điều phối trung tâm (State Machine):
``` C#
public class StateMachine
{
    public IState CurrentState { get; private set; }
    public void Tick()
    {
        CurrentState?.Tick();
    }
    public void FixedTick()
    {
        CurrentState?.FixedTick();
    }
    public void ChangeState(IState targetState)
    {
        if(CurrentState == targetState) return;
        CurrentState?.Exit();
        CurrentState = targetState;
        CurrentState?.Enter();
    }
    public void ForceSetState(IState state)
    {
        CurrentState?.Exit();
        CurrentState = state;
        CurrentState?.Enter();
    }
}
```
- 
	- CurrentState sẽ ghi nhớ trạng thái hiện tại, được khai báo get set để nhằm các class kế thừa nó không thay đổi được giá trị, chỉ đọc được.
	- Nó kích hoạt các hàm tick trong state hiện tại.
	- Nó sẽ quản lí cách các trạng thái chuyển đổi với nhau, đồng thời cũng update các frame của state.
- Tiếp theo sẽ tạo các class của từng trạng thái của `GameObject`
	- Trong các trạng thái bắt buộc phải có các phương thức ở trên Interface.
	- Các trạng thái đơn giản chỉ xử lí logic của `GameObject` và animation.
- Cuối cùng thì ta sẽ ref script State Machine vào trong `GameObject` thôi!