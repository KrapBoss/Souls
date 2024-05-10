using Unity.VisualScripting;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif


//InputAction으로부터 입력된 값을 넘겨받아 현재의 값들에 저장된다.

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool holdOnBreath;
        public bool run;
        public bool Grab;
        public bool throwing;
        public bool flash;
        public bool cameraView; //카메라 보기 키를 누른다.
        public float wheelValue;
        public bool funtion;
        public bool esc;
        public bool numOne;
        public bool numTwo;
        public bool tap;


        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;        //현재 게임 화면에 마우스가 위치한다.
        public bool cursorInputForLook = true;  //카메라가 마우스 커서의 움직임을 따라 갈 것인가?

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            //Debug.Log(value.Get<Vector2>());

            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnShift(InputValue value)
        {
            RunInput(value.isPressed);
        }

        public void OnSit(InputValue value)
        {
            HoldOnBreathInput(value.isPressed);
        }

        public void OnLeftMouse(InputValue value)
        {
            GrabInput(value.isPressed);
        }
        public void OnRightMouse(InputValue value)
        {
            ThrowInput(value.isPressed);
        }
        public void OnFlash(InputValue value)
        {
            FlashInput(value.isPressed);
        }
        public void OnCameraView(InputValue value)
        {
            CameraViewInput(value.isPressed);
        }
        public void OnWheel(InputValue value)
        {
            WheelInput(value.Get<Vector2>().y);
        }
        public void OnFunction(InputValue value)
        {
            FuntionInput(value.isPressed);
        }
        public void OnESC(InputValue value)
        {
            ESCInput(value.isPressed);
        }
        public void OnOne(InputValue value)
        {
            OneInput(value.isPressed);
        }
        public void OnTwo(InputValue value)
        {
            TwoInput(value.isPressed);
        }
        public void OnTap(InputValue value)
        {
            TapInput(value.isPressed);
        }
#endif

        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            //점프를 해서 공중에 떠 있을 경우에 FAlSE로 만든다.
            jump = newJumpState;
        }

        public void HoldOnBreathInput(bool newSprintState)
        {
            holdOnBreath = newSprintState;
        }

        public void RunInput(bool newSitState)
        {
            run = newSitState;
        }

        public void GrabInput(bool newGrabState)
        {
            Grab = newGrabState;
        }

        public void ThrowInput(bool newThrowState)
        {
            throwing = newThrowState;

        }

        public void FlashInput(bool newFuncState)
        {
            flash = newFuncState;
        }

        public void CameraViewInput(bool newCameraView)
        {
            cameraView = newCameraView;

        }

        public void WheelInput(float newWheel)
        {
            wheelValue = newWheel;
        }

        public void FuntionInput(bool newFuntion)
        {
            funtion = newFuntion;
        }

        public void ESCInput(bool newEsc)
        {
            esc = newEsc;
        }

        public void OneInput(bool newOne)
        {
            numOne = newOne;
        }
        public void TwoInput(bool newTwo)
        {
            numTwo = newTwo;
        }

        public void TapInput(bool newTap)
        {
            tap = newTap;
        }

        public void InitAll()
        {
            move = Vector2.zero;
            tap = false;
            numOne = false;
            numTwo = false;
            wheelValue = 0;
            cameraView = false;
            throwing = false;
            jump = false;
            holdOnBreath = false;
            run = false;
            look = Vector2.zero;
        }

        //현재 게임이 포커스를 유지하지 못하고 있다면 False : 유지한다면 True
        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

}