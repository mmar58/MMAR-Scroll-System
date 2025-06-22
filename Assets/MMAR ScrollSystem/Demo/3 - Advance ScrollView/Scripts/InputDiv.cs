using TMPro;
using UnityEngine;

namespace MMAR.ScrollSystem.Demo
{
    public class InputDiv : MonoBehaviour
    {
        public float showingSpeed;
        public Status status;
        public bool runAnimation;
        float hiddenHeight;
        [Header("Input Fields")]
        public TMP_InputField firstNameInput;
        public TMP_InputField lastNameInput;
        public TMP_InputField ageInput;
        public TMP_InputField occupationInput;
        AdvancedData curData;
        public static InputDiv instance;
        private void Start()
        {
            hiddenHeight=transform.position.y;
            instance = this;
        }
        private void Update()
        {
            if (runAnimation)
            {
                if (status == Status.Show)
                {
                    if (transform.position.y > hiddenHeight - 200)
                    {
                        transform.position -= new Vector3(0, showingSpeed * Time.deltaTime, 0);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, hiddenHeight - 200, transform.position.z);
                        runAnimation = false;
                    }
                }
            
                else if (status == Status.Hide)
                {
                    if (transform.position.y < hiddenHeight)
                    {
                        transform.position += new Vector3(0, showingSpeed * Time.deltaTime, 0);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, hiddenHeight, transform.position.z);
                        runAnimation = false;
                    }
                }
            }
        }
        public void Show()
        {
            status = Status.Show;
            runAnimation = true;
        }
        public void Hide()
        {
            status = Status.Hide;
            runAnimation = true;
        }
        public void ShowData(AdvancedData data)
        {
            curData = data;
            firstNameInput.text = data.FirstName;
            lastNameInput.text = data.LastName;
            ageInput.text = data.Age.ToString();
            occupationInput.text = data.Occupation;
            Show();
        }
        public void UpdateData()
        {
            curData.FirstName = firstNameInput.text; curData.LastName = lastNameInput.text;
            curData.Age = int.Parse(ageInput.text); curData.Occupation = occupationInput.text;
            curData.UpdateCellView();
            Hide();
        }
        public enum Status { Show,Hide}
    }
}