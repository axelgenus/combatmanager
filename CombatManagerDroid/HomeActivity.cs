using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

using CombatManager;


using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Android.OS;

namespace CombatManagerDroid
{
    [Activity (Label = "Combat Manager", Theme = "@android:style/Theme.Light.NoTitleBar")]
    public class HomeActivity : Activity, ActionBar.ITabListener
    {
        int count = 1;

        private LookupFragment _MonsterFragment;
        private CombatFragment _CombatFragment;

        protected override void OnCreate (Bundle bundle)
        {

            base.OnCreate (bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            FindViewById<Button>(Resource.Id.monstersButton).Click += delegate
            {
                ShowMonsterFragment();
            };
            FindViewById<Button>(Resource.Id.combatButton).Click += delegate
            {
                ShowCombatFragment();
            };

            //UpdateText();
        }

        private void ShowMonsterFragment()
        {
            FragmentTransaction ft = FragmentManager.BeginTransaction();

            if (_MonsterFragment == null)
            {
                _MonsterFragment = new LookupFragment();
            }
            ft.Replace(Resource.Id.bodyLayout, _MonsterFragment);
            ft.SetTransition(FragmentTransit.FragmentOpen);
            ft.Commit();
        }
        
        private void ShowCombatFragment()
        {
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            
            if (_CombatFragment == null)
            {
                _CombatFragment = new CombatFragment();
            }
            ft.Replace(Resource.Id.bodyLayout, _CombatFragment);
            ft.SetTransition(FragmentTransit.FragmentOpen);
            ft.Commit();
        }

        protected override void OnPause ()
        {
            base.OnPause ();
        }



        /*private void CreateLibraryAdapter()
        {
            new Thread(new ThreadStart(delegate {
               
                IList<String> str = null;

                if (MonsterText.Text.Trim().Length == 0)
                {
                    str = new List<String>(
                    from x in Monster.Monsters orderby x.Name ascending select x.Name );
                }
                else
                {
                    
                    str = new List<String>(
                        from x in Monster.Monsters where x.Name.ToUpper().Contains(MonsterText.Text.ToUpper())
                            orderby x.Name ascending select x.Name );
                }
                RunOnUiThread(delegate {
                       
                    //LibraryListView.Adapter = new LibraryListAdapter(CoreContext.Context, str);

                    FinishSelection();
                });
            })).Start();

        }*/

        private void FinishSelection()
        {

        }


        public void OnTabReselected (Android.App.ActionBar.Tab tab, FragmentTransaction ft)
        {
        }

        public void OnTabSelected (Android.App.ActionBar.Tab tab, FragmentTransaction ft)
        {
        }

        public void OnTabUnselected (Android.App.ActionBar.Tab tab, FragmentTransaction ft)
        {
        }


        /*private void UpdateText()
        {
            WebView view = FindViewById<WebView>(Resource.Id.webView1);
            
            EditText monsterText = FindViewById<EditText>(Resource.Id.editText1);

            if (monsterText.Text.Trim().Length >0)
            {
                var v = from x in CombatManager.Monster.Monsters where x.Name.ToUpper().Contains(monsterText.Text.ToUpper()) select x;
                var enumer = v.GetEnumerator();
                if (enumer.MoveNext())
                {
                    Monster vo = enumer.Current;
                    view.LoadData(MonsterHtmlCreator.CreateHtml(vo), "text/html", null);
                    
                }
                else
                {
                    
                    Monster m = CombatManager.Monster.Monsters[0];
                    view.LoadData(MonsterHtmlCreator.CreateHtml(m), "text/html", null);
                }
            }
        }*/
    }

   
}

