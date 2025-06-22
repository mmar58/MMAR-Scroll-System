

using UnityEngine;

namespace MMAR.ScrollSystem.Pagination
{
    public class PaginationController : Controller
    {
        Controller targetScrollController;
        public Vector2 cellSize=new Vector2(30, 30);
        public Color selectedColor;
        public Color defaultColor;
        [HideInInspector]
        public int selectedPage = 0;
        PaginationCellView lastSelectedCellView;
        public virtual void SetupTargetController(Controller targetScrollController)
        {
            this.targetScrollController = targetScrollController;
        }
        public virtual void UpdatePagination()
        {
            var pages = Mathf.Ceil(targetScrollController.dataList.Count / targetScrollController.itemsPerPage);
            dataList.Clear();
            for (int i = 0; i <= pages; i++)
            {
                var data = new PaginationData();
                data.pageNo = i+1;
                dataList.Add(data);
            }
            RefreshView();
            if (selectedPage < scrollRect.content.childCount)
            {
                lastSelectedCellView= scrollRect.content.GetChild(selectedPage).GetComponent<PaginationCellView>();
                lastSelectedCellView.image.color=selectedColor;
            }
        }
        public virtual void SelectPage(int page)
        {
            if(lastSelectedCellView != null)
            {
                lastSelectedCellView.Resetolor(defaultColor);
            }
            selectedPage = page-1;
            lastSelectedCellView = scrollRect.content.GetChild(selectedPage).GetComponent<PaginationCellView>();
            lastSelectedCellView.image.color = selectedColor;
            targetScrollController.RefreshView();
            targetScrollController.GetToTheTop();
        }
        #region Width and height
        public override float GetHeight(int index)
        {
            return cellSize.y;
        }
        public override float GetWidth(int index)
        {
            return cellSize.x;
        }
        #endregion
    }
}