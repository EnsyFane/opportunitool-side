import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeViewComponent } from './components/home-view/home-view.component';
import { OpportunitiesViewComponent } from './components/opportunities-view/opportunities-view.component';

const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeViewComponent },
    { path: 'opportunities', component: OpportunitiesViewComponent },
    { path: 'about/ambasadors', component: OpportunitiesViewComponent },
    { path: 'about/story', component: OpportunitiesViewComponent },
    { path: 'about/volunteering', component: OpportunitiesViewComponent },
    { path: 'about/privacy', component: OpportunitiesViewComponent },
    { path: 'login', component: OpportunitiesViewComponent },
    { path: 'register', component: OpportunitiesViewComponent },
    { path: 'my-account', component: OpportunitiesViewComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
