using System;
using System.Collections.Generic;
using UnityEngine;

namespace TakeArms.GameInput
{
    public class InputManager : MonoBehaviour
    {
        private static Dictionary<InputGroup, HashSet<InputBase>> _inputs = new Dictionary<InputGroup, HashSet<InputBase>>();
        private static InputGroup _activeInputGroup = InputGroup.Playing;
        private static InputManager _instance;
        public static InputManager Instance => _instance;

        [RuntimeInitializeOnLoadMethod]
        public static void InitializeObject()
        {
            _instance = new GameObject().AddComponent<InputManager>();
            _instance.name = "InputManager";
            _activeInputGroup = InputGroup.Playing;

            foreach (var inputGroup in Enum.GetValues(typeof(InputGroup)))
                _inputs.Add((InputGroup)inputGroup, new HashSet<InputBase>());

            DontDestroyOnLoad(_instance);
        }

        public void Update()
        {
            foreach (var input in _inputs[_activeInputGroup])
                input.CheckInput();
        }

        public static void RegisterKey(InputGroup inputGroup, InputKey key) => _inputs[inputGroup].Add(key);
        public static void RegisterKeys(InputGroup inputGroup, params InputKey[] keys)
        {
            foreach (var key in keys)
                _inputs[inputGroup].Add(key);
        }

        public static void RegisterAxis(InputGroup inputGroup, InputAxis inputAxis) => _inputs[inputGroup].Add(inputAxis);

        public static void RegisterDualAxis(InputGroup inputGroup, InputDualAxis axis) => _inputs[inputGroup].Add(axis);

        public static void SetInputGroup(InputGroup inputGroup) => _activeInputGroup = inputGroup;
    }

    public abstract class InputBase
    {
        public abstract void CheckInput();
    }

    public class InputKey : InputBase
    {
        public bool enabled;

        private KeyCode _key;
        private InputKeyState _inputKeyState;
        private event Action _action;

        public InputKey(KeyCode key, InputKeyState inputKeyState, Action action, bool enabled = true)
        {
            this.enabled = enabled;
            _key = key;
            _action = action;
            _inputKeyState = inputKeyState;
        }

        public override void CheckInput()
        {
            if (!enabled)
                return;

            switch (_inputKeyState)
            {
                case InputKeyState.KeyHold when Input.GetKey(_key):
                case InputKeyState.KeyDown when Input.GetKeyDown(_key):
                case InputKeyState.KeyUp when Input.GetKeyUp(_key):
                    _action?.Invoke();
                    return;
                default:
                    break;
            }
        }
    }

    public class InputDualAxis : InputBase
    {
        private string _axis1;
        private string _axis2;
        private Action<Vector2> _action;

        public InputDualAxis(string axis1, string axis2, Action<Vector2> action)
        {
            _axis1 = axis1;
            _axis2 = axis2;
            _action = action;
        }

        public override void CheckInput()
        {
            _action?.Invoke(new Vector2(Input.GetAxis(_axis1), Input.GetAxis(_axis2)));
        }
    }

    public class InputAxis : InputBase
    {
        private string _axis;
        private Action<float> _action;
        private AxisCondition _axisCondition;

        public InputAxis(string axis, Action<float> action, AxisCondition axisCondition)
        {
            _axis = axis;
            _action = action;
            _axisCondition = axisCondition;
        }

        public override void CheckInput()
        {
            var value = Input.GetAxis(_axis);

            switch (_axisCondition.condition)
            {
                case LogicCondition.None:
                case LogicCondition.GreaterThan when value > _axisCondition.value:
                case LogicCondition.GreaterThanOrEqual when value >= _axisCondition.value:
                case LogicCondition.LessThan when value < _axisCondition.value:
                case LogicCondition.LessThanOrEqual when value <= _axisCondition.value:
                case LogicCondition.Equal when value == _axisCondition.value:
                case LogicCondition.NotEqual when value != _axisCondition.value:
                    _action?.Invoke(value);
                    break;
                default:
                    break;
            }
        }
    }

    public struct AxisCondition
    {
        public float value { get; private set; }
        public LogicCondition condition { get; private set; }

        public AxisCondition(float value, LogicCondition condition)
        {
            this.value = value;
            this.condition = condition;
        }
    }

    public enum InputKeyState
    {
        KeyHold,
        KeyDown,
        KeyUp
    }

    public enum LogicCondition
    {
        None,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        Equal,
        NotEqual
    }

    // TODO: Overlook naming for this
    public enum InputGroup
    {
        Menu,
        Playing,
    }
}

