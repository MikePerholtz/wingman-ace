import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
	// {path: '', redirectTo: "albums", pathMatch: 'full'},
	// {path: '', redirectTo: 'albums', pathMatch: 'full'},
	// {path: 'albums', component: AlbumList },
	// {path: 'album/:id', component: AlbumDisplay },
	// {path: 'album/edit/:id', component: AlbumEditor },
	// {path: 'artists', component: ArtistList },
	// {path: 'artist/:id', component: ArtistDisplay },
	// {path: 'options', component: OptionsComponent },
	// { path: 'login', component: LoginComponent },
	// { path: 'logout', component: LoginComponent },
	// { path: 'about', component: AboutComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
    providers: []
})

export class AppRoutingModule { } 