using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfDataGridSample;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace UnitTestBasicSample
{
    /// <summary>
    /// MainWindowViewModel単体テスト
    /// </summary>
    [TestClass]
    public class UnitTestBasicSample
    {
        /// <summary>
        /// オブジェクトが正しく作成されるかテストします。
        /// </summary>
        [TestMethod]
        public void CreationTest()
        {
            using (var vm = new MainWindowViewModel())
            {
                Assert.IsNotNull(vm);

                var src = vm.GridDataCollectionView;
                Assert.IsNotNull(src);
                Assert.IsTrue(0 < src.Count);
            }
        }

        /// <summary>
        /// イベントが発生したらTrueになります。
        /// </summary>
        private bool FEventHappened = false;

        /// <summary>
        /// コレクションを更新してイベントが発生するかどうかテストします。
        /// </summary>
        [TestMethod]
        public void UpdateCollectionTest()
        {
            using (var vm = new MainWindowViewModel())
            {
                vm.PropertyChanged += FViewModel_PropertyChanged;

                var c = new ObservableCollection<CorrOrder>();
                c.Add(new CorrOrder(1, ItemType.Fruits, "バナナ", "えええええおおおおお", 1234));

                var s = (CollectionView)CollectionViewSource.GetDefaultView(c);

                // privateなメンバへアクセスするためアクセスオブジェクトを作成
                var obj = new PrivateObject(vm);
                obj.SetProperty("GridDataCollectionView", s);
                vm.PropertyChanged -= FViewModel_PropertyChanged;

                Assert.IsTrue(this.FEventHappened);
            }
        }

        /// <summary>
        /// プロパティの発生時に呼ばれるイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Assert.AreEqual("GridDataCollectionView", e.PropertyName);
            this.FEventHappened = true;
        }

    }
}
