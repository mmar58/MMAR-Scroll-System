
namespace MMAR.ScrollSystem.Demo
{
    using TMPro;
    public class AdvancedCellView : CellView
    {
        public TextMeshProUGUI firtNameText, lastNameText, ageText, occupationText;
        public override void SetData(Data data)
        {
            base.SetData(data);
            var curData = data as AdvancedData;
            firtNameText.text = curData.index+"."+curData.FirstName;
            lastNameText.text = curData.LastName;
            ageText.text = curData.Age+"";
            occupationText.text = curData.Occupation;
        }
        public void OnUpdateButton()
        {
            InputDiv.instance.ShowData(data as AdvancedData);
        }
        public void OnDeleteButton()
        {
            controller.dataList.Remove(data);
            controller.RefreshView();
            controller.updatePagination = true;
        }
    }
}