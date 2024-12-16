import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { authGuard } from './_guards/auth.guard';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { preventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { memberDetailedResolver } from './_resolvers/member-detailed.resolver';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { adminGuard } from './_guards/admin.guard';
import { TestHomeComponent } from './test/test-home/test-home.component';
import { TestEmployeeComponent } from './test/test-employee/test-employee.component';
import { TestExampleComponent } from './test/test-example/test-example.component';
import { TestExampleComponentsComponent } from './test/test-example-components/test-example-components.component';
import { TestMyCampaignComponent } from './test/test-my-campaign/test-my-campaign.component';
import { TestSearchComponent } from './test/test-search/test-search.component';

export const routes: Routes = [            //These are all different routes
//    {path: '', component: HomeComponent},
    {path: '', component: TestMyCampaignComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [authGuard],          //canActivate uses auth.guard.ts
        children: [
            {path: 'members', component: MemberListComponent},
            {path: 'members/:username', component: MemberDetailComponent, resolve: {member: memberDetailedResolver}},
            {path: 'member/edit', component: MemberEditComponent, canDeactivate: [preventUnsavedChangesGuard]},
            {path: 'lists', component: ListsComponent},
            {path: 'messages', component: MessagesComponent},
            {path: 'admin', component: AdminPanelComponent, canActivate: [adminGuard]},
            {path: 'testing', component:TestHomeComponent},
            {path: 'testing/E', component:TestEmployeeComponent},
            {path: 'testing/Example', component:TestExampleComponent},
            {path: 'testing/Example2', component:TestExampleComponentsComponent},

            {path: 'testing/ChosenCampaign', component:TestHomeComponent},
            {path: 'testing/MyCampaign', component:TestMyCampaignComponent},
            {path: 'testing/MyCampaign/Search', component:TestSearchComponent},

        ]
    },
    {path: 'errors', component: TestErrorsComponent},
    {path: 'not-found', component: NotFoundComponent},
    {path: 'server-error', component: ServerErrorComponent},
    {path: '**', component: HomeComponent, pathMatch: 'full'},
];
