using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using NUnit.Framework;
using System;
using static System.Net.Mime.MediaTypeNames;
using Application = FlaUI.Core.Application;
using Assert = NUnit.Framework.Assert;

namespace WinAppDriverTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Application app;
        private UIA3Automation automation;
        private Window mainWindow;

        [SetUp]
        public void Setup()
        {
            var solutionRoot = Path.GetFullPath(
       Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..")
   );

            var exePath = Path.Combine(
                solutionRoot,
                "WinFormsApp",
                "bin",
                "Release",
                "net8.0-windows",
                "WinFormsApp.exe"
            );

            Console.WriteLine($"EXE PATH: {exePath}");
            Assert.That(File.Exists(exePath), Is.True,
    $"Cannot find exe: {exePath}");
            app = Application.Launch(exePath);

            automation = new UIA3Automation();

            mainWindow = app.GetMainWindow(automation);

            Assert.That(mainWindow, Is.Not.Null);

            app.WaitWhileBusy();

            Thread.Sleep(500);
        }

        [Test]
        public void TreeView_Test()
        {
            Console.WriteLine("TreeView_Test");
            var all = mainWindow.FindAllDescendants();


            var ezTreeViewControl = mainWindow
               .FindFirstDescendant(cf => cf.ByAutomationId("ezTreeViewControl"));
            Assert.That(ezTreeViewControl, Is.Not.Null);
            var treeView = ezTreeViewControl
              .FindFirstDescendant(cf => cf.ByAutomationId("_treeView")).AsTree();
            Assert.That(treeView, Is.Not.Null);
        

           
        }

        [Test]
        public void btnPrint_Test()
        {
            Console.WriteLine("btnPrint_Test");
            var all = mainWindow.FindAllDescendants();

            var btnPrint = mainWindow
               .FindFirstDescendant(cf => cf.ByName("印　刷")).AsButton();

            Assert.That(btnPrint, Is.Not.Null);
            btnPrint.Invoke();
            Thread.Sleep(200);
            all = mainWindow.FindAllDescendants();

            var btnPrintPhotoList = mainWindow
              .FindFirstDescendant(cf => cf.ByName("写真一覧印刷 (P)...")).AsMenuItem();
            Assert.That(btnPrintPhotoList, Is.Not.Null);
            btnPrintPhotoList.Click();
            Thread.Sleep(200);
            var dialog = Retry.WhileNull(
    () => automation.GetDesktop()
        .FindFirstDescendant(cf =>
            cf.ByControlType(ControlType.Window)
            .And(cf.ByName("PrintCaption")))
        ?.AsWindow(),
    TimeSpan.FromSeconds(5))
    .Result;

            Assert.That(dialog, Is.Not.Null);

            dialog.SetForeground();

            Thread.Sleep(200);

            // ENTER thay vì click button
            
            Keyboard.Press(VirtualKeyShort.RETURN);

            Thread.Sleep(200);
        }

        [Test]
        public void CheckBox()
        {
            Console.WriteLine("CheckBox_Test");
            var all = mainWindow.FindAllDescendants();


            var userCtl = mainWindow
               .FindFirstDescendant(cf => cf.ByAutomationId("userCtl"));

            var checkBox = userCtl
              .FindFirstDescendant(cf => cf.ByAutomationId("checkBox")).AsCheckBox();
            Assert.That(checkBox, Is.Not.Null);
            Assert.That(checkBox.IsChecked, Is.False);

            var pictureBox = userCtl
             .FindFirstDescendant(cf => cf.ByAutomationId("pictureBox"));
            Assert.That(pictureBox, Is.Not.Null);
            //checkBox.Click();
            Assert.That(checkBox.Patterns.Toggle.IsSupported, Is.True); 
            checkBox.Patterns.Toggle.Pattern.Toggle();

            Thread.Sleep(1000);
            var isChecked = Retry.WhileFalse(
                () => {
                    var cb = userCtl.FindFirstDescendant(cf => cf.ByAutomationId("checkBox"))?.AsCheckBox(); 
                    return cb != null && cb.IsChecked == true; 
                }, timeout: TimeSpan.FromSeconds(5),
                interval: TimeSpan.FromMilliseconds(200)).Result;
            Assert.That(isChecked, Is.True);


            pictureBox = userCtl
             .FindFirstDescendant(cf => cf.ByAutomationId("pictureBox"));
            Assert.That(pictureBox, Is.Not.Null);
            Assert.That(pictureBox.Properties.Name.Value, Is.EqualTo("HasImage"));
        }

        [Test]
        public void AdditionTest()
        {
            Console.WriteLine("AdditionTest");
            var all = mainWindow.FindAllDescendants();
            // Tìm label kết quả
            var resultEdit = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("resultLb"))?.AsTextBox();
            Assert.That(resultEdit, Is.Not.Null);
            Console.WriteLine("resultEdit.Text:" + resultEdit.Text);
            Assert.That(resultEdit.Text == "result", Is.True);

            var userCtl = mainWindow
               .FindFirstDescendant(cf => cf.ByAutomationId("userCtl"));

            Assert.That(userCtl, Is.Not.Null);
            var resultLb = userCtl.FindFirstDescendant(cf => cf.ByAutomationId("resultLb"))?.AsLabel();
            Console.WriteLine("resultLb.Name:"+resultLb.Name);
            Console.WriteLine("resultLb.AutomationId:" + resultLb.AutomationId);
            Console.WriteLine("resultLb.Text:" + resultLb.Text);
            Console.WriteLine("resultLb.HelpText:" + resultLb.HelpText);
            Assert.That(resultLb, Is.Not.Null);
            Assert.That(resultLb.Text == "result", Is.True);
            // Tìm button
            var clickBtn = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("clickBtn"))?.AsButton();
            Assert.That(clickBtn, Is.Not.Null);

            clickBtn.Invoke();

            Thread.Sleep(500);

            resultEdit = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("resultLb"))?.AsTextBox();
            Console.WriteLine("resultEdit.Text:" + resultEdit.Text);
            Assert.That(resultEdit.Text == "Ket qua", Is.True);

            resultLb = userCtl.FindFirstDescendant(cf => cf.ByAutomationId("resultLb"))?.AsLabel();
            Assert.That(resultLb, Is.Not.Null);
            Assert.That(resultLb.Text == "Ket qua", Is.True);
            Console.WriteLine("resultLb.HelpText:" + resultLb.HelpText);
        }
        [Test]
        public void btnOpen_ClickTest()
        {
            Console.WriteLine("btnOpen_ClickTest");
            var all = mainWindow.FindAllDescendants();

            //foreach (var item in all)
            //{
            //    Console.WriteLine(
            //        $"Name={item.Name}, " +
            //        $"AutomationId={item.AutomationId}, " +
            //        $"Type={item.ControlType}");
            //}
            // tìm textbox
            var resultLb = mainWindow
                .FindFirstDescendant(cf => cf.ByAutomationId("resultLb"))
                ?.AsTextBox();

            Assert.That(resultLb, Is.Not.Null);

            Console.WriteLine("Before: " + resultLb.Text);

            Assert.That(resultLb.Text, Is.EqualTo("result"));

            // tìm ToolStripButton
            var clickBtn = mainWindow.FindFirstDescendant(
     cf => cf.ByName("Open Folder")).AsButton();

//            var clickBtn = mainWindow.FindFirstDescendant(
//cf => cf.ByAutomationId("btnOpen")).AsButton();
            Assert.That(clickBtn, Is.Not.Null);

            // click
            clickBtn.Invoke();

            // đọc lại textbox
            resultLb = mainWindow
                .FindFirstDescendant(cf => cf.ByAutomationId("resultLb"))
                ?.AsTextBox();

            Console.WriteLine("After: " + resultLb.Text);

            Assert.That(resultLb.Text, Is.EqualTo("btnOpen_Click"));
        }

        [Test]
        public void panel1_EnableTest()
        {
            Console.WriteLine("panel1_EnableTest");
            var all = mainWindow.FindAllDescendants();

      
            var panelMenu = mainWindow
                .FindFirstDescendant(cf => cf.ByAutomationId("panelMenu"));

            Assert.That(panelMenu, Is.Not.Null);
            Assert.That(panelMenu.IsEnabled, Is.True);


            var panelLb = mainWindow
               .FindFirstDescendant(cf => cf.ByAutomationId("panelLb"));

            Assert.That(panelLb, Is.Null);

            var clickBtn = mainWindow.FindFirstDescendant(
cf => cf.ByName("Open Folder")).AsButton();
            Assert.That(clickBtn, Is.Not.Null);

            // click
            clickBtn.Invoke();
            Thread.Sleep(200);
            all = mainWindow.FindAllDescendants();
            panelLb = mainWindow
               .FindFirstDescendant(cf => cf.ByAutomationId("panelLb"));

            Assert.That(panelLb, Is.Not.Null);
        
        }

    

        [Test]
        public void btnInfoView_DisableTest()
        {
            Console.WriteLine("btnInfoView_DisableTest");
            var all = mainWindow.FindAllDescendants();


            var userCtl = mainWindow
                .FindFirstDescendant(cf => cf.ByAutomationId("userCtl"));

            Assert.That(userCtl, Is.Not.Null);

           var btnInfoView = mainWindow.FindFirstDescendant(cf => cf.ByName("InfoView")).AsCheckBox();
            //var btnInfoView = mainWindow.FindFirstDescendant(cf => cf.ByName("情報表示")).AsCheckBox();
            Assert.That(btnInfoView, Is.Not.Null);

            Assert.That(btnInfoView.IsChecked, Is.True);
            Console.WriteLine("btnInfoView_DisableTest before IsChecked:"+ btnInfoView.IsChecked);
            // click
            btnInfoView.Click();


            Thread.Sleep(200);
          

            btnInfoView = mainWindow.FindFirstDescendant(cf => cf.ByName("InfoView")).AsCheckBox();
            //btnInfoView = mainWindow.FindFirstDescendant(cf => cf.ByName("情報表示")).AsCheckBox();

               Assert.That(btnInfoView.IsChecked, Is.False);

            userCtl = mainWindow
            .FindFirstDescendant(cf => cf.ByAutomationId("userCtl"));

            Assert.That(userCtl, Is.Null);
        }

//        [Test]
//        public void btnInfoViewMenu_DisableTest()
//        {
//            Console.WriteLine("btnInfoViewMenu_DisableTest");
//            var all = mainWindow.FindAllDescendants();

//            var menuBarCtrl = mainWindow
//               .FindFirstDescendant(cf => cf.ByAutomationId("menuBarCtrl"));

//            Assert.That(menuBarCtrl, Is.Not.Null);
//            var allMenuBar = menuBarCtrl.FindAllDescendants();
//            var userCtl = mainWindow
//                .FindFirstDescendant(cf => cf.ByAutomationId("userCtl"));

//            Assert.That(userCtl, Is.Not.Null);

//            var btnView = mainWindow.FindFirstDescendant(
//cf => cf.ByAutomationId("btnView"));
//            Assert.That(btnView, Is.Not.Null);
//            btnView.Click();

//            Thread.Sleep(200);
//            all = mainWindow.FindAllDescendants();
//            allMenuBar = menuBarCtrl.FindAllDescendants();
       

//            var mItem_View_PhotoDisplay = mainWindow.FindFirstDescendant(
//cf => cf.ByName("写真表示(V)")).AsMenuItem();
//            Assert.That(mItem_View_PhotoDisplay, Is.Not.Null);

//            Assert.That(mItem_View_PhotoDisplay.IsChecked, Is.True);
//            //Console.WriteLine("btnInfoView_DisableTest before IsChecked:" + mItem_View_PhotoDisplay.IsChecked);
//            // click
//            mItem_View_PhotoDisplay.Invoke();


//            Thread.Sleep(200);


//            mItem_View_PhotoDisplay = mainWindow.FindFirstDescendant(
//         cf => cf.ByName("写真表示(V)")).AsMenuItem();


//            //  Console.WriteLine("btnInfoViewMenu_DisableTest after IsChecked:" + mItem_View_PhotoDisplay.IsChecked);
//            Assert.That(mItem_View_PhotoDisplay, Is.Null);
//            userCtl = mainWindow
//                .FindFirstDescendant(cf => cf.ByAutomationId("userCtl"));

//            Assert.That(userCtl, Is.Null);

//        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(500);
            automation?.Dispose();

            if (app != null && !app.HasExited)
            {
                app.Close();
            }
        }
    }
}