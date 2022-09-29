
using UnityEngine;

namespace StardropTools
{
    [CreateAssetMenu(menuName = "Stardrop / Scriptable Values / Scriptable Float")]
    public class ScriptableFloat : ScriptableValue
    {
        [SerializeField] float defaultFloat;
        [SerializeField] float value;

        public readonly GameEvent<float> OnFloatChanged = new GameEvent<float>();

        public float Float { get => value; set => SetFloat(value); }
        public float DefaultFloat => defaultFloat;

        protected override void InvokeEvents(bool invoke)
        {
            if (invoke == false)
                return;

            OnValueChanged?.Invoke();
            OnFloatChanged?.Invoke(value);
        }

        public override void Default(bool invokeEvents = true)
        {
            if (invokeEvents == false)
                return;

            value = defaultFloat;
            InvokeEvents(invokeEvents);
        }



        public void SetFloat(float value, bool invokeEvents = true)
        {
            this.value = value;
            InvokeEvents(invokeEvents);
        }

        public void SetFloat(float value) => SetFloat(value, true);


        public void SetDefaultFloat(float defaultFloat, bool setValueEqualsToDefault, bool invokeEvents = true)
        {
            this.defaultFloat = defaultFloat;

            if (setValueEqualsToDefault)
                value = defaultFloat;

            InvokeEvents(invokeEvents);
        }

        public float AddValue(float valueToAdd, bool invokeEvents = true)
        {
            value += valueToAdd;
            InvokeEvents(invokeEvents);

            return value;
        }

        public float SubtractValue(float valueToSubtract, bool invokeEvents = true)
        {
            value -= valueToSubtract;
            InvokeEvents(invokeEvents);

            return value;
        }
    }
}